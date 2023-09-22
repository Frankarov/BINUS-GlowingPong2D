using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewSkinControl : MonoBehaviour
{
    
    public SpriteRenderer spriteRenderer;
    public Text textColor;
    private void Awake()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        textColor = GetComponent<Text>();
        Debug.Log("Awake berhasil");

    }

    public void UpdateSkinColor()
    {
        spriteRenderer.color = SkinSelector.skinColor;
        textColor.color = SkinSelector.skinColor2;
        Debug.Log("update berhasil");
    }
}
