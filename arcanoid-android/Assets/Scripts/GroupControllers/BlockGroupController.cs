using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockGroupController : MonoBehaviour {

    GameObject blockChceck;
    public string scenToLoad;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        blockChceck = GameObject.FindGameObjectWithTag("Block");

        if (blockChceck == null) {
            SceneManager.LoadScene(scenToLoad);
        }
    }
}
