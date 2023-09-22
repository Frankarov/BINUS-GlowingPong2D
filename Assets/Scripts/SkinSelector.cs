using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SkinSelector : MonoBehaviour
{
    [SerializeField] private SkinManager skinManager;

    //public SpriteRenderer spriteRenderer;
    public static Color skinColor = Color.black;
    public static Color skinColor2 = Color.red;      
    [SerializeField] private NewSkinControl playerSkin;
    [SerializeField] private NewSkinControl textSkin;
    [SerializeField] private GameObject scoreColor;


    public void SetSkinColorRed()
    {
        SkinManager.chooseColor = Color.red;
        PindahScene();

        Debug.Log("updatecolorberhasil");
    }

    public void SetSkinColorGreen()
    {
        Debug.Log("updatecolorberhasil");
        SkinManager.chooseColor = Color.green; ;
        Debug.Log("updatecolorberhasil");
        PindahScene();

    }

    public void SetSkinColorBlue()
    {
        Debug.Log("updatecolorberhasil");
        SkinManager.chooseColor = Color.cyan;
        PindahScene();

    }
    public void SetSkinColorYellow()
    {
        SkinManager.chooseColor = Color.yellow;
        PindahScene();

        Debug.Log("updatecolorberhasil");
    }
    public void SetSkinColorPink()
    {
        SkinManager.chooseColor = Color.magenta;
        PindahScene();

        Debug.Log("updatecolorberhasil");
    }

    public void SetSkinColorBlack()
    {
        SkinManager.chooseColor = Color.black;
        PindahScene();

        Debug.Log("updatecolorberhasil");
    }

    public void SetSkinColorWhite()
    {
        SkinManager.chooseColor = Color.white;
        PindahScene();

        Debug.Log("updatecolorberhasil");
    }



    private void PindahScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 12)
        {
            SceneManager.LoadScene("GameAI");
        }
        if (SceneManager.GetActiveScene().buildIndex == 14)
        {
            SceneManager.LoadScene("GameAI2");
        }
    }



    //private void ChangeSkinColor()
    //{


    //    GameObject player = GameObject.FindWithTag("Player");
    //    //GameObject scoreColor = GameObject.FindWithTag("ScoreColor");

    //    NewSkinControl newskinControl = player.GetComponent<NewSkinControl>();
    //    //NewSkinControl new2skinControl = scoreColor.GetComponent<NewSkinControl>();
    //    newskinControl.UpdateSkinColor();
    //    //new2skinControl.UpdateSkinColor();
    //}
}
