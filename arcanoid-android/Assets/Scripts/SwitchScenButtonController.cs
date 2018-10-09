using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenButtonController : MonoBehaviour {

    public string scenToLoad;
	

    private void OnMouseDown()
    {
        SceneManager.LoadScene(scenToLoad);
    }
}
