using Assets.Scripts.Consts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlockGroupController : MonoBehaviour {

    GameObject blockChceck;
    string scenName;
    GameObject ball;

    public string scenToLoad;


    // Use this for initialization
    void Start () {
        ball = GameObject.FindGameObjectWithTag(Tags.BALL);
        scenName = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {
        blockChceck = GameObject.FindGameObjectWithTag(Tags.BLOCK);

        if (blockChceck == null) {
            int score=ball.GetComponent<BallComboController>().GetScore();
            if (score > PlayerPrefs.GetInt(scenName+"HighScore")) {
                PlayerPrefs.SetInt(scenName+"HighScore", score);
            }
            SceneManager.LoadScene(scenToLoad);
        }
    }
}
