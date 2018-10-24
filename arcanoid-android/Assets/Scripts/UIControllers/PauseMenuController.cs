using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {

    public static bool GamePaused = false;

    public GameObject pauzeButton;



    public  void PauseGame() {
        GamePaused = true;
        Time.timeScale = 0f;
        this.gameObject.SetActive(true);
        pauzeButton.SetActive(false);
    }


    public void ResumeGame() {
        GamePaused = false;
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
        pauzeButton.SetActive(true);
    }

}
