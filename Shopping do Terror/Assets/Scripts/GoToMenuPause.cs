using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GoToMenuPause : MonoBehaviour
{

    public Image B1;
    public Image B2;
    public void LoadScene() {
        B1.material.color = Color.white;
        B2.material.color = Color.white;
        SceneManager.LoadScene("00 - Menu Inicial");
        Time.timeScale = 1f;
    }
}
