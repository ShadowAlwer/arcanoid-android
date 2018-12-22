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
    ScoreGUIController scoreGUI;
    
    public int lives = 3;
    public bool godMode = false;
    public Transform ballPoint;
    public PauseMenuController pauseMenu;
    public PauseMenuController victoryPauseMenu;
    public PauseMenuController defeatPauseMenu;
    public Text healthText;
    public string musicTheme;


    // Use this for initialization
    void Start () {
        ball = GameObject.FindGameObjectWithTag(Tags.BALL);
        scenName = SceneManager.GetActiveScene().name;
        scoreGUI = FindObjectOfType<ScoreGUIController>();

        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        FindObjectOfType<AudioMenager>().PlayTheme(musicTheme);
        SetHealthText();
    }
	
	// Update is called once per frame
	void Update () {
        blockChceck = GameObject.FindGameObjectWithTag(Tags.BLOCK);

        if (blockChceck == null) {
            Victory();
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape down");
            pauseMenu.PauseGame();
        }

    }

    private void Victory()
    {
        victoryPauseMenu.Victory();
        int score = scoreGUI.GetScore(); 
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
                SetHealthText();
            }
        }
    }

    public void AddHealth() {
        lives++;
        SetHealthText();
    }

    public void SetHealthText() {
        healthText.text = "" + (lives - 1);
    }

    private void Defeat()
    {
        defeatPauseMenu.Defeat();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            pauseMenu.PauseGame();
        }
    }

}
