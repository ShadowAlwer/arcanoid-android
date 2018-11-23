using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    public string scenToLoad;


    public void LoadScene()
    {
        if (FindObjectOfType<PauseMenuController>().GamePaused)
        {
            Debug.Log("Resuming");
            FindObjectOfType<PauseMenuController>().ResumeGame();
        }
        SceneManager.LoadScene(scenToLoad);
        
    }



    public void QuitGame() {
        Application.Quit();
    }
    
}
