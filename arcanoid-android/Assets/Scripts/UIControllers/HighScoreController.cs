using Assets.Scripts.Consts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

    private const string HIGH_SCORE_KEY = "HighScore";
    private const string HIGH_SCORE_TEXT = " High Score:\n" ;

    public Text highScoreText;



    void Start () {
        string highScore=PlayerPrefs.GetInt(Levels.PHYSICS_TEST+HIGH_SCORE_KEY, 0).ToString();
        highScoreText.text = HIGH_SCORE_TEXT + highScore+"\n";

        highScoreText.text += GetAllHighScores();
    }

    string GetAllHighScores() {
        string allHighScores = "";
        string tmp;
        Levels levels = new Levels();

        foreach(string levelType in Levels.LEVEL_TYPES) {
            foreach (string levelName in (string[])levels.GetType().GetField(levelType).GetValue(levels)) {
               tmp = GetHighScoreByLevelName(levelName);
                Debug.Log("Level Name="+levelName);
                Debug.Log("TMP=" + tmp);
                allHighScores = levelName +HIGH_SCORE_TEXT + tmp + "\n";
            }
        }

        return allHighScores;
    }


    string GetHighScoreByLevelName(string levelName) {
        string highScore = PlayerPrefs.GetInt(levelName + HIGH_SCORE_KEY, 0).ToString();
        return highScore;
    }



    public void ResetHighScoreAll() {
        highScoreText.text = HIGH_SCORE_TEXT + 0;
        PlayerPrefs.DeleteAll();
    }

    //private void onlevelwasloaded(int level)
    //{

    //}
}
