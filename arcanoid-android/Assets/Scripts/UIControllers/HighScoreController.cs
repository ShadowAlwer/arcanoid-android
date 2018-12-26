using Assets.Scripts.Consts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

    private const string HIGH_SCORE_KEY = "HighScore";
    private const string HIGH_SCORE_TEXT = ": ";
    private const string NO_HIGH_SCORE_TEXT = "------";
	
    public GameObject panelPrefab;

    List<GameObject> highScoresPanels;

    void Start () {
        highScoresPanels = new List<GameObject>();
        GetAllHighScores();
    }

    void GetAllHighScores() {
        string allHighScores = "";
        string tmp;
        Levels levels = new Levels();

        foreach(string levelType in Levels.LEVEL_TYPES) {
            foreach (string levelName in (string[])levels.GetType().GetField(levelType).GetValue(levels)) {
                GameObject panel = Instantiate(panelPrefab) as GameObject;
                tmp = GetHighScoreByLevelName(levelName);
                panel.transform.SetParent(this.transform, false);
                panel.GetComponentInChildren<Text>().text = levelName +HIGH_SCORE_TEXT + tmp;
                highScoresPanels.Add(panel);
            }
        }

    }


    string GetHighScoreByLevelName(string levelName) {
        string highScore = PlayerPrefs.GetInt(levelName + HIGH_SCORE_KEY, 0).ToString();

        if (highScore == "0") {
            highScore = NO_HIGH_SCORE_TEXT;
        }
        return highScore;
    }


    public void ResetHighScoreAll() {
        PlayerPrefs.DeleteAll();
        foreach (GameObject panel in highScoresPanels) {
            Destroy(panel);
        }
        highScoresPanels.Clear();
        GetAllHighScores();
    }

}
