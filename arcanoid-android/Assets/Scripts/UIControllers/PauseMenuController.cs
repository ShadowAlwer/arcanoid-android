using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {

    public bool GamePaused = false;

    public GameObject levelGUI;

    public  void PauseGame() {
        GamePaused = true;
        Time.timeScale = 0f;
        this.gameObject.SetActive(true);
        levelGUI.SetActive(false);
    }

    public void ResumeGame() {
        GamePaused = false;
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
        levelGUI.SetActive(true);
    }

    public void Victory()
    {
        PauseGame();
    }

    public void Defeat()
    {
        PauseGame();
    }



}
