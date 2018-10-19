using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallComboController : MonoBehaviour {

    public Text scoreUI;
    public Text comboUI;

    const string SCORE_STRING = "Score: ";
    const string COMBO_STRING = "Combo: ";

    int scoreCounter=0;
    int comboCounter=0;




    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Platform"))
        {
            comboCounter = 0;
            comboUI.text = COMBO_STRING + comboCounter;
        }

        if (collision.gameObject.CompareTag("Block")) {
            comboCounter++;
            scoreCounter += comboCounter * collision.gameObject.GetComponent<BlockController>().GetPointValue();
            scoreUI.text = SCORE_STRING + scoreCounter;
            comboUI.text = COMBO_STRING + comboCounter;

        }

    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update () {		
	}
}
