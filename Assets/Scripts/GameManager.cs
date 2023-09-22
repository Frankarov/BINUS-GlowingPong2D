using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //skinselector
    public GameObject[] skinPrefabs;
    



    private int waitingTime = 1;
    
    
    private IEnumerator WaitingTime(float seconds)
    {
            
            yield return new WaitForSeconds(seconds);
            
            if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            this.gameObject.SendMessage("ChangeScene", "LeftPostGame");
        }


            if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            this.gameObject.SendMessage("ChangeScene", "AILeftPost");
        }

            if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            this.gameObject.SendMessage("ChangeScene", "AILeftPost2");
        }

    }

    private IEnumerator WaitingTimeR(float seconds)
    {
        //WinRCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(seconds);


        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
           this.gameObject.SendMessage("ChangeScene", "RightPostGame");
        }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            this.gameObject.SendMessage("ChangeScene", "AIRightPost");
        }
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            this.gameObject.SendMessage("ChangeScene", "AIRightPost2");
        }
    }


    public int PlayerScoreL = 0;
    public int PlayerScoreR = 0;

    public Text txtPlayerScoreL;
    public Text txtPlayerScoreR;

    public static GameManager instance;
    [SerializeField] private Canvas pauseCanvas;
    private bool isPause;
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start() //isi nilai playerscore ke ui
    {
        txtPlayerScoreL.text = PlayerScoreL.ToString();
        txtPlayerScoreR.text = PlayerScoreR.ToString();

        //int selectedSkin = PlayerPrefs.GetInt("selectedSkin");
        //GameObject prefab = skinPrefabs[selectedSkin];
    }



    public void ScoreCheck()
    {
        if (PlayerScoreL == 10)
        {
            StartCoroutine(WaitingTime(waitingTime));

            Debug.Log("Pemain kiri menang");
            
        }
        else if (PlayerScoreR == 10)
        {
            StartCoroutine(WaitingTimeR(waitingTime));
            Debug.Log("Pemain kanan menang");
            
        }
    }

    public void Score(string wallID)
    {
        if (wallID == "Line L")
        {
            //untuk score
            PlayerScoreR = PlayerScoreR + 1;
            txtPlayerScoreR.text = PlayerScoreR.ToString(); //UI + int
            ScoreCheck();
        }
        else
        {
            
            PlayerScoreL = PlayerScoreL + 1;
            txtPlayerScoreL.text = PlayerScoreL.ToString();
            ScoreCheck();
        }
    }

    public void PauseGame()
    {
        if(isPause == false)
        {
            isPause = true;
            pauseCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeGame()
    {
        if (isPause == true)
        {
            isPause = false;
            pauseCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
    
    public void RestartGame()
    {
        
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            GetComponent<SceneManagement>().ChangeScene("Game");
            
        }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            Debug.Log("keganti");
            GetComponent<SceneManagement>().ChangeScene("SkinSelect1");
        }
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            Debug.Log("keganti");
            GetComponent<SceneManagement>().ChangeScene("SkinSelect2");
        }   
            Time.timeScale = 1;
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }


}


