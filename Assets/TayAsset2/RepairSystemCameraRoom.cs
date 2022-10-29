using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairSystemCameraRoom : MonoBehaviour
{
    public TheSystemInCamararoomTest system;
    public bool SoundReButton = false;
    public float SoundReTime = 10f;
    public bool CamReButton = false;
    public float CamReTime = 10f;
    void Update()
    {
        SoundRepair();
    }
    public void SoundRepairButton()
    {
        SoundReButton = true;
    }
    public void SoundRepair()
    {
        if (SoundReButton)
        {
            SoundReTime -= Time.deltaTime;
            if (SoundReTime <= 0f)
            {
                Debug.Log("O");
                SoundReEvent();
                SoundReButton = false;
                SoundReTime = 0f;
            }
        }
    }
    public void SoundReEvent()
    {
        system.SoundCheck = true;
    }

    //Cam
    public void CamRepairButton()
    {
        CamReButton = true;
    }
    public void CamRepair()
    {
        if (CamReButton)
        {
            CamReTime -= Time.deltaTime;
            if (CamReTime <= 0f)
            {
                Debug.Log("O");
                CamReEvent();
                CamReButton = false;
                CamReTime = 0f;
            }
        }
    }
    public void CamReEvent()
    {
        system.CamCheck = true;
    }
}
