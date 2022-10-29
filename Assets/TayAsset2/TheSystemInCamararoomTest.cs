using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheSystemInCamararoomTest : MonoBehaviour
{
    public float SoundSystem;
    public float CamSystem;
    public float AirSystem;
    public float SoundEventTriger = 100f;
    public float CamEventTriger = 200f;
    public float AirEventTriger = 300f;
    public bool SoundCheck = true;
    public bool CamCheck = true;
    public bool AirCheck = true;
    public CameraButtonController camera;
    void Update()
    {
        Soundtime();
        //CamTime();
        //Airtime();
    }
    public void Soundtime()
    {
        if (SoundCheck)
        {
            SoundSystem += Time.deltaTime;
            if (SoundSystem / SoundEventTriger >= 1f)
            {
                Debug.Log("O");
                SoundEvent();
                SoundCheck = false;
                SoundSystem = 0f;
            }
        }
        
    }
    public void SoundEvent()
    {
        //buttonGameobj.setactive false
       // camera.DisableAllCam();
    }
   
}
