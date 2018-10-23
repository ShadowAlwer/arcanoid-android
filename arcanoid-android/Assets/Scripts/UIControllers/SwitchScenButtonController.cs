using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenButtonController : MonoBehaviour {

    public string scenToLoad;


    public void LoadScene()
    {
        SceneManager.LoadScene(scenToLoad);
    }
    
}
