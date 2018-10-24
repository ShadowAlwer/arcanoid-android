using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    public string scenToLoad;


    public void LoadScene()
    {
        if (PauseMenuController.GamePaused)
        {
            PauseMenuController.GamePaused = false;
            Time.timeScale = 1f;
        }
        SceneManager.LoadScene(scenToLoad);
        
    }


    public void QuitGame() {
        Application.Quit();
    }
    
}
