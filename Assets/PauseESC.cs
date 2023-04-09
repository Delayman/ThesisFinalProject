using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseESC : MonoBehaviour
{
    public GameObject pausemenu;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pausemenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                resumePress();
            }
            else
            {
                pauseOpen();
            }
        }
    }
    public void pauseOpen()
    {
        pausemenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible= true;
        isPaused= true;
    }
    public void resumePress()
    {
        pausemenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible= false;  
        isPaused = false;
    }
}
