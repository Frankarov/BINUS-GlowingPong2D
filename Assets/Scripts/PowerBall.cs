using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBall : MonoBehaviour
{

    public CameraShake cameraShake;
    public PlayerControls player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReverseInput()
    {

        player.speed *= -1;

    }

    public void ScreenShake()
    {
        cameraShake.shouldShake = true;
    }

}
