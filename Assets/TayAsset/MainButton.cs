using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainButton : MonoBehaviour
{
    [SerializeField] GameObject SettingPage;
    [SerializeField] GameObject PlayPage;
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

}
