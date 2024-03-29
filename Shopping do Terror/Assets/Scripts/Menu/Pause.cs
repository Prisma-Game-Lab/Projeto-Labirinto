﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;

    public static bool cantPause = false;

    public GameObject pauseMenu;

    void PauseGame () {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame () {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    } 

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !cantPause) {
            if (isPaused) {
                ResumeGame();
            }

            else {
                PauseGame();
            }
        }
    }
}
