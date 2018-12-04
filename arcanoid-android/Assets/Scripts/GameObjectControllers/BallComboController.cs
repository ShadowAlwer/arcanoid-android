using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Consts;

public class BallComboController : MonoBehaviour {

    public Text scoreUI;
    public Text comboUI;

    const string SCORE_STRING = "$ ";
    const string COMBO_STRING = "x";

    int score=0;
    int combo=1;




    public void AddScore(int points) {
        
        score += combo * points;
        scoreUI.text = SCORE_STRING + score;       
        combo++;
        comboUI.text = COMBO_STRING + combo;
    }

    public void ResetCombo() {
        combo = 1;
        comboUI.text = COMBO_STRING + combo;

    }

    public int GetScore() {
        return score;
    }

    public int GetCombo()
    {
        return combo;
    }

}
