using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

    private const string PHYSICS_HIGH_SCORE_KEY = "PhysicsTestHighScore";
    private const string HIGH_SCORE_TEXT = "High Score: \n";

    public Text highScoreText;



    void Start () {
        string highScore=PlayerPrefs.GetInt(PHYSICS_HIGH_SCORE_KEY, 0).ToString();
        highScoreText.text = HIGH_SCORE_TEXT + highScore;

    }

    public void ResetHighScoreAll() {
        highScoreText.text = HIGH_SCORE_TEXT + 0;
        PlayerPrefs.DeleteAll();
    }

    //private void onlevelwasloaded(int level)
    //{

    //}
}
