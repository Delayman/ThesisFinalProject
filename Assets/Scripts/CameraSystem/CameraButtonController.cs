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
}
