using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{
    private int time = 1;
    [SerializeField] private Canvas ScoreCanvas;
    public CameraShake cameraShake;
    public AudioSource scoreSound;

    private IEnumerator WaitingTime(float seconds)
    {
        ScoreCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        ScoreCanvas.gameObject.SetActive(false);
    }




    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        Debug.Log("OnTriggerLine_Success");
        if (hitInfo.name == "Ball")
        {

            StartCoroutine(WaitingTime(time));
            string wallName = transform.name;
            scoreSound.Play();
            //memanggil method Score di GameManager.cs
            GameManager.instance.Score(wallName);
            Debug.Log(hitInfo);
            //memanggil method RestartGame() di BallControl.cs
            
            hitInfo.gameObject.SendMessage("RestartGame", 5.0f, SendMessageOptions.RequireReceiver);
            //cameraShake.shouldShake = true;




        }

    }

}
