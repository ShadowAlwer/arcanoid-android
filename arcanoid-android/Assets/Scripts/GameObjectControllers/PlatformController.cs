using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    public float speed = 20f;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1f; //TODO:check why timeScale zeros after victory
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
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled &&  touch.tapCount<2)
                {
                    if (touch.position.x > (Screen.width / 2))
                    {
                        MoveRight(); //moves platform right
                    }

                    if (touch.position.x < (Screen.width / 2))
                    {
                        MoveLeft(); //moves platform left
                    }
                    //break;
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
