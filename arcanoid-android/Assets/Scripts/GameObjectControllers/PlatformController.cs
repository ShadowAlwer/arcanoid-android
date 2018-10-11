using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    public float speed = 20f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //inputs for PC-----------------------------------------------------
        float direction = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * direction * speed;
        //-----------------------------------------------------------------------

        //inputs for android-----------------------------------------------------
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);   //chyba usuwa dotyk z listy
            //Touch touch = Input.touches[0];    
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                if (touch.position.x > (Screen.width / 2))
                {
                    MoveRight(); //moves platform right
                }

                if (touch.position.x < (Screen.width / 2))
                {
                    MoveLeft(); //moves platform left
                }
            }
        }
        //-----------------------------------------------------------------------
    }

    void MoveRight() {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    void MoveLeft() {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
    }
}
