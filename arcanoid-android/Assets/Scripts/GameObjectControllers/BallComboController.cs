using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallComboController : MonoBehaviour {

    public Text scoreUI;
    public Text comboUI;

    const string SCORE_STRING = "Score: ";
    const string COMBO_STRING = "Combo: ";

    int score=0;
    int combo=0;


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Platform"))
        {
            combo = 0;
            comboUI.text = COMBO_STRING + combo;
        }

        if (collision.gameObject.CompareTag("Block")) {
            combo++;
            score += combo * collision.gameObject.GetComponent<BlockController>().GetPointValue();
            scoreUI.text = SCORE_STRING + score;
            comboUI.text = COMBO_STRING + combo;

        }

    }

    public int GetScore() {
        return score;
    }

    public int GetCombo()
    {
        return combo;
    }

    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update () {		
	}
}
