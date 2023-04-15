using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CameraUIController : MonoBehaviour
{
    [SerializeField] private GameObject camUI;
    [SerializeField] private string role = "Watcher";

    private CameraButtonController camBtnCtr;
    private CameraButton camExitBtn;

    private GameObject watcher;

    private AudioListener audio;

    private void Start()
    {
        camBtnCtr = FindObjectOfType<CameraButtonController>();
        camExitBtn = FindObjectOfType<CameraButton>();

        camUI.SetActive(false);
    }

    public void HideCamUI()
    {
        LockCursor();
        camBtnCtr.DisableAllCam(); 
        camUI.SetActive(false);

        camExitBtn.isOn = false;
        camExitBtn.ToggleCam();
    }
    
    public void StartCamUI()
    {
        FreeCursor();
        camBtnCtr.Cam1();
        camUI.SetActive(true);
    }

    private static void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    private static void FreeCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
