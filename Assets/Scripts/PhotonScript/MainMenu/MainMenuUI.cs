using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuUI : MonoBehaviour
{
    public GameObject OptionCanvas;
    public GameObject TutorialCanvas;
    public GameObject ESC;
    public void OnStartGameAndNoPressed()
    {
        SceneManager.LoadScene("Scenes/Lobby");
    }
    public void OnStartGameAndYesPressed()
    {
        SceneManager.LoadScene("Scenes/Tutorial_Scene");
    }

    public void OnQuitPressed()
    {
        Application.Quit();
    }

    public void OnOptionPressed()
    {
        OptionCanvas.SetActive(true);
    }
    public void OnStartGamePress()
    {
        TutorialCanvas.SetActive(true);
    }
    public void OnLeaveSinglePress()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
    public void OnOptionPause()
    {
        ESC.SetActive(false);
    }
    public void OnOptionBack()
    {
        ESC.SetActive(true);
    }

}
