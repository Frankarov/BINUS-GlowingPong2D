using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AIBall : MonoBehaviour
{
    private int time = 1;
    [SerializeField] private Canvas ReverseCanvas;


    private IEnumerator WaitingTime(float seconds)
    {
        ReverseCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        ReverseCanvas.gameObject.SetActive(false);
    }

    public GameObject ReverseTimeCanvas;
    public GameObject QuakeCanvas;

    
    public PlayerControls player;
    public AudioSource HitSound;
    public AudioSource BlackSoundSource;
    public AudioSource GreenSoundSource;
    public AudioSource RedSoundSource;
    public AudioSource QuakeSoundSource;
    public ParticleSystem collisionParticle;
    private Rigidbody2D rb2d;
    public float ballForceX = 30;
    public float ballForceY = -15;
    [SerializeField] private CameraShake cameraShake;
    void Start()
    {
        HitSound = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>(); //ambil rigidbody
        Invoke("GoBall", 2); //pnggil goball dlm 2 detik
    }

    void GoBall()
    {
        GameObject MiddleRecycle = GameObject.Find("Middle Line");
        Destroy(MiddleRecycle);
        float rand = Random.Range(0, 2); //random nilai
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(ballForceX, ballForceY)) ; //tambah force
        }
        else
        {
            rb2d.AddForce(new Vector2(-ballForceX, -ballForceY));
        }
    }

    void ResetBall() //buat nilai transform jdi 0 
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player")) //jika hit player
            
        {
            //cameraShake.shouldShake = true;
            
            HitSound.Play();
            Vector2 vel;
            vel.x = rb2d.velocity.x + 3f;
            vel.y = (rb2d.velocity.y) + (coll.collider.attachedRigidbody.velocity.y / 3);

           // while (Mathf.Abs(vel.x) < 10f)
           // {
           //     vel.x += 20;
            //}

            rb2d.velocity = vel;
            EmitParticle(90);
        }

        if (coll.collider.CompareTag("Wall"))
        {
            EmitParticle(130);
        }

        if (coll.gameObject.CompareTag("BlackBall"))
        {
            
            Debug.Log("kenahitam");
            BlackSoundSource.Play();
            Destroy(coll.gameObject, 0.2f);
            //coll.gameObject.GetComponent<PowerBall>().ReverseInput();

        }

    }



    public GameObject RacketL;
    public GameObject RacketR;
    public Text txtReverseCountDown;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("RedBall"))
        {

            StartCoroutine(QuakeTime(1.1f));
            //RedSound.Play();
            RedSoundSource.Play();
            QuakeSoundSource.Play();
            cameraShake.shouldShake = true;
            //coll.gameObject.GetComponent<PowerBall>().ScreenShake();
            Destroy(coll.gameObject, 0.2f);

            QuakeCanvas.SetActive(true);

            IEnumerator QuakeTime(float quakeWaitTime)
            {
                yield return new WaitForSeconds(quakeWaitTime);
                QuakeSoundSource.Stop();
                QuakeCanvas.SetActive(false);
            }


        }

        float originalSpeed = player.speed;


        if (coll.gameObject.CompareTag("GreenBall"))
        {
            SpriteRenderer RacketLChange = RacketL.GetComponent<SpriteRenderer>();
            SpriteRenderer RacketRChange = RacketR.GetComponent<SpriteRenderer>();

            StartCoroutine(ChangeColorL(RacketL.GetComponent<SpriteRenderer>(), Color.green, 3f));
            StartCoroutine(ChangeColorR(RacketR.GetComponent<SpriteRenderer>(), Color.green, 3f));
            StartCoroutine(WaitingTime(time));
            StartCoroutine(CountdownCoroutine());
            StartCoroutine(RevertPlayerSpeed(originalSpeed, 3.0f));
            GreenSoundSource.Play();
            
            player.speed *= -1;
            //player[1].speed *= -1;
            ReverseTimeCanvas.SetActive(true);

            IEnumerator ChangeColorL(SpriteRenderer RacketLChange, Color newColorL, float seconds)
            {

                Color originalColorL = RacketLChange.color;

                RacketLChange.color = newColorL;
                yield return new WaitForSeconds(seconds);

                RacketLChange.color = originalColorL;
            }

            IEnumerator ChangeColorR(SpriteRenderer RacketRChange, Color newColorR, float seconds)
            {

                Color originalColorR = RacketRChange.color;

                RacketRChange.color = newColorR;
                yield return new WaitForSeconds(seconds);

                RacketRChange.color = originalColorR;
            }

            IEnumerator CountdownCoroutine()
            {
                int count = 3;
                while (count > 0)
                {
                    txtReverseCountDown.text = count.ToString();
                    yield return new WaitForSeconds(1.0f);
                    count--;
                }
                txtReverseCountDown.text = "0";
                //ReverseTimeCanvas.SetActive(false);
            }


            IEnumerator RevertPlayerSpeed(float originalSpeed, float waitTime)
            {
                yield return new WaitForSeconds(waitTime);
                player.speed = originalSpeed;
                //player[1].speed = originalSpeed;
                ReverseTimeCanvas.SetActive(false);
            }

            Destroy(coll.gameObject, 0.2f);
            

        }




    } //TUTUP VOID ONTRIGGERENTER2D


    private void EmitParticle(int amount)
    {
        collisionParticle.Emit(amount);
    }
}
