using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class SettingMenu : MonoBehaviour
{
    public AudioMixer MusicMixer;
    public AudioMixer SfxMixer;

    public Slider musicSlider;
    public Slider SfxSlider;
    public Toggle FullScreentoggle;
    //public TMP_Dropdown ResolutionDropDown;
    //Resolution[] resolutions;

    //public Text test;

    //public TMP_Dropdown resolutionDropDown;
    //public Resolution[] resolutions;
    //public List<Resolution> filteredResolution;
    //public float CurrentReFreshRate;
    //public int CurrentResolutionIndex = 0;
    public void Awake()
    {
        SetMusicSilderValue();
        SetSfxSilderValue();
        SetFullScreenToggle();
    }
    public void Start()
    {
         this.gameObject.SetActive(false);
        // SetResolutionList();
       // SetResolutionList2();
    }
    public void SetMusicSilderValue()
    {
        float musicMixerValue;
        MusicMixer.GetFloat("MusicMaster", out musicMixerValue);
        musicSlider.value = musicMixerValue;
    }
    public void SetSfxSilderValue()
    {
        float SfxMixerValue;
        SfxMixer.GetFloat("SFXMaster", out SfxMixerValue);
        SfxSlider.value = SfxMixerValue;
    }
    public void SetFullScreenToggle()
    {
        FullScreentoggle.isOn = Screen.fullScreen;
    }
    public void SetMusicVolume(float volume)
    {
        MusicMixer.SetFloat("MusicMaster", volume);
    }
    public void SetSfxVolume(float volume)
    {
        SfxMixer.SetFloat("SFXMaster", volume);
    }
    public void SetFullScreen(bool Isfullscreen)
    {
        Screen.fullScreen = Isfullscreen;
    }
    //public void SetResolutionList()
    //{
    //    resolutions = Screen.resolutions;
    //    ResolutionDropDown.ClearOptions();
    //    List<string> options = new List<string>();

    //    int CurrentResolutionIndex = 0;
    //    for (int i = 0; i < resolutions.Length ; i++)
    //    {
    //        string option = resolutions[i].width + "x" + resolutions[i].height;
    //        options.Add(option);
    //        test.text = options.Count.ToString();

    //        /*   if (!options.Contains(option))
    //           {
    //               options.Add(option);
    //               test.text = options.Count.ToString();
    //           }
    //           */

    //        if (resolutions[i].width == Screen.currentResolution.width &&
    //            resolutions[i].height == Screen.currentResolution.height)
    //        {
    //            CurrentResolutionIndex = i;
    //        }
    //    }
    //    ResolutionDropDown.AddOptions(options);
    //    ResolutionDropDown.value = CurrentResolutionIndex;
    //    ResolutionDropDown.RefreshShownValue();
    //}
    //public void SetResolution(int resolutionindex)
    //{
    //    Resolution resolution = resolutions[resolutionindex];
    //    Screen.SetResolution(resolution.width , resolution.height ,Screen.fullScreen);
    //}
    //public void SetResolutionList2()
    //{
    //    resolutions = Screen.resolutions;
    //    filteredResolution = new List<Resolution>();
    //    resolutionDropDown.ClearOptions();
    //    CurrentReFreshRate = Screen.currentResolution.refreshRate;

    //    for (int i = 0; i < resolutions.Length; i++)
    //    {
    //        if (resolutions[i].refreshRate == CurrentReFreshRate)
    //        {
    //            filteredResolution.Add(resolutions[i]);
    //        }
    //    }

    //    List<string> options = new List<string>();
    //    for (int i = 0; i < filteredResolution.Count; i++)
    //    {
    //        string resolutionOption = filteredResolution[i].width + "x" + filteredResolution[i].height + " " + filteredResolution[i].refreshRate + "Hz";
    //        options.Add(resolutionOption);
    //        if (filteredResolution[i].width == Screen.width && filteredResolution[i].height == Screen.height)
    //        {
    //            CurrentResolutionIndex = i;
    //        }

    //    }
    //    resolutionDropDown.AddOptions(options);
    //    resolutionDropDown.value = CurrentResolutionIndex;
    //    resolutionDropDown.RefreshShownValue();

    //}
    //public void SetResolution(int resolutionIndex)
    //{
    //    Resolution resolution = filteredResolution[resolutionIndex];
    //    Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    //}
    public void JumpSceneTest()
    {
        SceneManager.LoadScene("TestJumpMusicScene");
    }
    public void OFFOptionButton()
    {
        this.gameObject.SetActive(false);
    }
}
