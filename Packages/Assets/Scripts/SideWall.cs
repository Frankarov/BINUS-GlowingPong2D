using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("teskena");
    }
    // Start is called before the first frame update
    //void onTriggerEnter2D(Collider2D other)
    //{

    //    //if (hitInfo.name == "Ball")

    //    //{
    //    //    string wallName = transform.name;
    //    //    GameManager.instance.Score(wallName);
    //    //    hitInfo.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
    //    //}


    //}
}
