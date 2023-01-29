using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuUI : MonoBehaviour
{
    public GameObject OptionCanvas;
    public void OnStartGamePressed()
    {
        SceneManager.LoadScene("Scenes/Lobby");
    }

    public void OnQuitPressed()
    {
        Application.Quit();
    }

    public void OnOptionPressed()
    {
        OptionCanvas.SetActive(true);
    }
    
}
