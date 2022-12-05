using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraButtonController : MonoBehaviour
{
    [SerializeField] private GameObject[] cameraArray;

    private void Start()
    {
        foreach (var _camera in cameraArray)
        {
            _camera.SetActive(false);
        }
    }

    public void DisableAllCam()
    {
        foreach (var _camera in cameraArray)
        {
            _camera.SetActive(false);
        }
        FindDistractPos.camID = 0;
    }
 
    public void Cam1()
    {
        DisableAllCam();
        cameraArray[0].SetActive(true);
        FindDistractPos.camID = 1;
    }
    
    public void Cam2()
    {
        DisableAllCam();
        cameraArray[1].SetActive(true);
        FindDistractPos.camID = 2;
    }
    public void Cam3()
    {
        DisableAllCam();
        cameraArray[2].SetActive(true);
        FindDistractPos.camID = 3;
    }
    public void Cam4()
    {
        DisableAllCam();
        cameraArray[3].SetActive(true);
        FindDistractPos.camID = 4;

    }
    public void Cam5()
    {
        DisableAllCam();
        cameraArray[4].SetActive(true);
        FindDistractPos.camID = 5;

    }
    public void Cam6()
    {
        DisableAllCam();
        cameraArray[5].SetActive(true);
        FindDistractPos.camID = 6;

    }
    public void Cam7()
    {
        DisableAllCam();
        cameraArray[6].SetActive(true);
        FindDistractPos.camID = 7;

    }
    public void Cam8()
    {
        DisableAllCam();
        cameraArray[7].SetActive(true);
        FindDistractPos.camID = 8;

    }
    public void Cam9()
    {
        DisableAllCam();
        cameraArray[8].SetActive(true);
        FindDistractPos.camID = 9;

    }
    public void Cam10()
    {
        DisableAllCam();
        cameraArray[9].SetActive(true);
        FindDistractPos.camID = 10;

    }
    public void Cam11()
    {
        DisableAllCam();
        cameraArray[10].SetActive(true);
        FindDistractPos.camID = 11;

    }
}
