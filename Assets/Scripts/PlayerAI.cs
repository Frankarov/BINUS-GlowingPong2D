using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAI : MonoBehaviour
{
    [SerializeField] private GameObject ballObject;
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 10f;
    public float boundY = 4;
    private Rigidbody2D rb2d;

    //untuk AI


    private float aiSpeed = 5f;
    private float aiMovementThreshold = 0.1f;


    void Start()
    {

        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            aiSpeed = 5f;
        }
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            aiSpeed = 9f;
        }


            rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;
        if (Input.GetKey(moveUp))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }
        rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;

        //GameObject ball = GameObject.FindWithTag("Ball");
        //if (ball != null)
        //{
            float distance = ballObject.transform.position.y - transform.position.y;
            if (Mathf.Abs(distance) > aiMovementThreshold)
            {
                // Move the AI paddle towards the ball
                Vector2 aiVel = Vector2.up * Mathf.Sign(distance) * aiSpeed;
                rb2d.velocity = aiVel;
            }
        //}


    } //update



}