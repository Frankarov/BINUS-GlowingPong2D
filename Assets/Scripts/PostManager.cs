using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PostManager: MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SceneManager.GetActiveScene().buildIndex == 8)
            {
                GetComponent<SceneManagement>().ChangeScene("Game");

            }
            if (SceneManager.GetActiveScene().buildIndex == 9)
            {
                GetComponent<SceneManagement>().ChangeScene("Game");

            }

            if (SceneManager.GetActiveScene().buildIndex == 10)
            {
                GetComponent<SceneManagement>().ChangeScene("MapSelect");

            }
            if (SceneManager.GetActiveScene().buildIndex == 16)
            {
                GetComponent<SceneManagement>().ChangeScene("MapSelect");

            }
        }

            // GetComponent<SceneManagement>().ChangeScene("Game");


        }


}


