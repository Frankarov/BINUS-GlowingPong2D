using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetColorScore : MonoBehaviour
{
    //[SerializeField] private SkinManager skinManager;
    void Start()
    {
        
        //skinManager = FindObjectOfType<SkinManager>();
        GetComponent<Text>().color = SkinManager.chooseColor;

    }

    void Update()
    {
        
    }
}
