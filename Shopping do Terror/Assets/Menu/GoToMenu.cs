using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    public void LoadScene() {
        SceneManager.LoadScene("00 - Menu Inicial");
        Time.timeScale = 1f;
    }
}
