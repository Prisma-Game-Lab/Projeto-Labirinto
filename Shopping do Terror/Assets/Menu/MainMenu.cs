using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("02 - Level 01");
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("01 - Credits");
    }

    public void LoadConfigScene()
    {
        //SceneManager.LoadScene("");
    }

    public void LoadControlsScene()
    {
        //SceneManager.LoadScene("");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
