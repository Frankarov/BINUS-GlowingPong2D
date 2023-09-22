using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerColor : MonoBehaviour
{
    //[SerializeField] private SkinManager skinManager;
    private SpriteRenderer spriteRendererNew;

    // Start is called before the first frame update
    void Start()
    {
        
        //skinManager = FindObjectOfType<SkinManager>();
        spriteRendererNew = GetComponent<SpriteRenderer>(); 
        spriteRendererNew.color = SkinManager.chooseColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
