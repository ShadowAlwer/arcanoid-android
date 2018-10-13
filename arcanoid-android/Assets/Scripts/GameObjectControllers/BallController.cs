using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public bool started = false;
    public float speed = 10f;
    //Camera cam;
    GameObject platform;
    // Use this for initialization
    void Start()
    {
        //GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        platform = GameObject.FindGameObjectWithTag("Platform");
    }

    // Update is called once per frame
    void Update()
    {

        if (started == false)
        {

            bool ballStart = false;
            if (Application.platform == RuntimePlatform.Android)
            {

                //TODO:poprawić rozróżnianie między dotknięciami, multitouch!!
                if (Input.touchCount > 0)
                {
                    foreach (Touch touch in Input.touches)
                    {
                        if (touch.phase == TouchPhase.Ended && touch.tapCount > 1)
                        {
                            ballStart = true;
                        }
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ballStart = true;
                }
            }

            //jeżeli wykryto szybki dotyk lub spacje rozpocznij ruch kulki
            if (ballStart)
            {
                //Debug.Log(Input.GetKeyDown(KeyCode.Space));
                Vector2 tmp = transform.position;
                Vector2 v;
                if (tmp.x < 0)
                {
                    v = new Vector2(-1, 1);
                }
                else
                {
                    v = new Vector2(1, 1);
                }
                GetComponent<Rigidbody2D>().velocity = Vector2.ClampMagnitude(v, 1) * speed;

                started = true;
            }
            //jeśli nie wykryto spacji lub szybkiego dotyku przesuń kulkę na platformę
            else
            {
                Vector2 tmp = transform.position;
                //Debug.Log("x =" + tmp.x+" y =" + tmp.y);
                Vector2 tmpPlatform = platform.transform.position;
                tmp.x = tmpPlatform.x;
                if (tmp.x < 0)
                {
                    tmp.x -= 0.15f;
                }
                else
                {
                    tmp.x += 0.15f;
                }

                transform.position = tmp;
            }
        }

        if (started == true)
        {
            if (GetComponent<Rigidbody2D>().velocity.magnitude != speed)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.ClampMagnitude(GetComponent<Rigidbody2D>().velocity, 1) * speed;
            }
        }
    }


}
