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
    private List<RoleSetting> roleSettings;

    private GameObject watcher;

    private AudioListener audio;

    private void Start()
    {
        roleSettings = FindObjectsOfType<RoleSetting>().ToList();
        camBtnCtr = FindObjectOfType<CameraButtonController>();
        camExitBtn = FindObjectOfType<CameraButton>();

        camUI.SetActive(false);
    }

    public void HideCamUI()
    {
        // audio.enabled = true;
        
        LockCursor();
        camBtnCtr.DisableAllCam(); 
        camUI.SetActive(false);

        camExitBtn.isOn = false;
        camExitBtn.ToggleCam();
    }
    
    public void StartCamUI()
    {
        FreeCursor();
        DisableAudioWhenStartCam();
        camBtnCtr.Cam1();
        camUI.SetActive(true);
    }

    // private bool FindWatcher()
    // {
    //     foreach (var _role in roleSettings)
    //     {
    //         if (_role.roleName == role)
    //         {
    //             watcher = _role.gameObject;
    //             return true;
    //         }
    //     }
    //
    //     return false;
    // }

    private void DisableAudioWhenStartCam()
    {
        // var isfound = FindWatcher();

        // if (isfound)
        // {
        //     audio = watcher.GetComponentInChildren(typeof(AudioListener)) as AudioListener;
        //     audio.enabled = false;
        // }
        // else
        //     Debug.Log($"Player with <color=red>WATCHER role</color> was NOT FOUND");
        
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
