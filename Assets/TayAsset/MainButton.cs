using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    [SerializeField] GameObject SettingPage;
    [SerializeField] GameObject PlayPage;
    

    public void Start()
    {
        SettingPage.SetActive(false);
    }
    public void PlayGameButton()
    {
        SettingPage.SetActive(false);
        PlayPage.SetActive(true);

    }
    public void SettingButton()
    {
        SettingPage.SetActive(true);
        PlayPage.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void Create()
    {
        SceneManager.LoadScene("");
    }
    public void Join()
    {
        SceneManager.LoadScene("");
    }

}
