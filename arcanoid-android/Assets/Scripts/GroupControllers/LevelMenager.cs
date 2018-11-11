using Assets.Scripts.Consts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenager : MonoBehaviour {

    GameObject blockChceck;
    string scenName;
    GameObject ball;
    
    public int lives = 3;
    public bool godMode = false;
    public Transform ballPoint;
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

    public void BottomWallHit() {
        if (!godMode) {
            lives--;
            if (lives <= 0)
            {
                Destroy(ball);
                SceneManager.LoadScene(scenToLoad);
            }
            else {
            
                ball.GetComponent<BallController>().Stop(ballPoint);
            }
        }
    }
}
