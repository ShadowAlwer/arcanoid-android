using Assets.Scripts.Consts;
using System;
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
    public PauseMenuController victoryPauseMenu;
    public PauseMenuController defeatPauseMenu;
    public string musicTheme;


    // Use this for initialization
    void Start () {
        ball = GameObject.FindGameObjectWithTag(Tags.BALL);
        scenName = SceneManager.GetActiveScene().name;


        Debug.Log("Starting level menager");
        if (Time.timeScale == 0f)
        {
            Debug.Log("Restarting game time scale");
            Time.timeScale = 1f;

        }

        FindObjectOfType<AudioMenager>().PlayTheme(musicTheme);


    }
	
	// Update is called once per frame
	void Update () {
        blockChceck = GameObject.FindGameObjectWithTag(Tags.BLOCK);

        if (blockChceck == null) {
            Victory();
            
        }
    }

    private void Victory()
    {
        victoryPauseMenu.Victory();
        int score = ball.GetComponent<BallComboController>().GetScore();
        if (score > PlayerPrefs.GetInt(scenName + "HighScore"))
        {
            PlayerPrefs.SetInt(scenName + "HighScore", score);
        }
        
    }

    public void BottomWallHit() {
        if (!godMode) {
            lives--;
            if (lives <= 0)
            {
                Defeat();                
            }
            else {
            
                ball.GetComponent<BallController>().Stop(ballPoint);
            }
        }
    }

    private void Defeat()
    {
        defeatPauseMenu.Defeat();
    }
}
