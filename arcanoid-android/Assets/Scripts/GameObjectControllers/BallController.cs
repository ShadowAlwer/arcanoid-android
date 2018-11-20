using Assets.Scripts.Consts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    public bool started = false;
    public float speed = 10f;
    public LevelMenager levelMenager;
    public float minAcelerate = 1.1f;
    public float acelerationCooldown=2;
    public Text acelerationDisplay;
    public Slider acelerationSlider;
    public Image acelerationSliderImage;

    public Color cdBar;
    public Color fullBar;
    float lastAcelerationTime;

    GameObject platform;
    
    // Use this for initialization
    void Start()
    {      
        platform = GameObject.FindGameObjectWithTag(Tags.PLATFORM);
    }

    // Update is called once per frame
    void Update()
    {

        if (started == false)
        {

            bool ballStart = false;
            if (Application.platform == RuntimePlatform.Android)
            {

                
                if (Input.touchCount > 0)
                {
                    foreach (Touch touch in Input.touches)
                    {
                        if (touch.phase == TouchPhase.Ended && touch.tapCount > 1)
                        {
                            ballStart = true;
                            lastAcelerationTime = Time.time;
                            ResetSlider();
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
            if (SystemInfo.supportsAccelerometer) {
                Acelerate();
            }
            if (GetComponent<Rigidbody2D>().velocity.magnitude != speed)
            {
                    GetComponent<Rigidbody2D>().velocity = Vector2.ClampMagnitude(GetComponent<Rigidbody2D>().velocity, 1) * speed;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Tags.BOTTOM_WALL)
        {
            levelMenager.BottomWallHit();
        }
    }


    private void Acelerate() {

        float x = Input.acceleration.x;
        float y = Input.acceleration.y;
        float magnitude2D =Mathf.Sqrt( x * x + y * y);

        if (acelerationDisplay != null) {
            acelerationDisplay.text = magnitude2D.ToString();
        }


        if (Time.time < lastAcelerationTime + acelerationCooldown) {
            UpdateSlider();
        }
        else if (magnitude2D>minAcelerate) {
            Vector2 aceleration = new Vector2(x, y);
            //aceleration = (aceleration + GetComponent<Rigidbody2D>().velocity);  //średnia z wektora prszyśpieszenia i szybkości
            aceleration.Normalize();
            GetComponent<Rigidbody2D>().velocity =aceleration* speed;
            lastAcelerationTime = Time.time;
            acelerationSlider.value = 0;
            acelerationSliderImage.color = cdBar;
        }
    }

    private void UpdateSlider() {
        acelerationSlider.value = (Time.time - lastAcelerationTime) / acelerationCooldown;
        if (acelerationSlider.value > 0.98)
        {
            acelerationSliderImage.color = fullBar;
        }            
    }

    private void ResetSlider() {
        acelerationSlider.value = 0;
        acelerationSliderImage.color = cdBar;
    }
 




    public void Stop(Transform ballPoint) {
        started = false;
        transform.position = ballPoint.position;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ResetSlider();
    }


}
