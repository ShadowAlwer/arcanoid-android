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
    public bool isPowerUpBall;

    public Color cdBar;
    public Color fullBar;
    float lastAcelerationTime;

    BallComboController comboController;
    GameObject platform;
    
    // Use this for initialization
    void Start()
    {
        levelMenager = FindObjectOfType<LevelMenager>();
        comboController = FindObjectOfType<BallComboController>();
        platform = GameObject.FindGameObjectWithTag(Tags.PLATFORM);

        if (isPowerUpBall) {
            GameObject[] powerups = GameObject.FindGameObjectsWithTag(Tags.POWER_UP);
            GameObject[] balls = GameObject.FindGameObjectsWithTag(Tags.BALL);
            GameObject[] rockets = GameObject.FindGameObjectsWithTag(Tags.ROCKET);
            Collider2D collider = GetComponent<Collider2D>();

            foreach (GameObject powerup in powerups) {
                Physics2D.IgnoreCollision(collider, powerup.GetComponent<Collider2D>());
            }           
            foreach (GameObject ball in balls)
            {
                Physics2D.IgnoreCollision(collider, ball.GetComponent<Collider2D>());
            }          
            foreach (GameObject rocket in rockets)
            {
                Physics2D.IgnoreCollision(collider, rocket.GetComponent<Collider2D>());
            }
        }   
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
            if (SystemInfo.supportsAccelerometer && !isPowerUpBall) {
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
            if (isPowerUpBall)
            {
                Destroy(gameObject);
            }
            else
            {
                levelMenager.BottomWallHit();
            }
        }
        if (collision.gameObject.CompareTag(Tags.PLATFORM) && !isPowerUpBall)
        {
            comboController.ResetCombo();
        }

        if (collision.gameObject.CompareTag(Tags.BLOCK))
        {
            comboController.AddScore(collision.gameObject.GetComponent<BlockController>().GetPointValue());
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
        if (!isPowerUpBall)
        {
            acelerationSlider.value = 0;
            acelerationSliderImage.color = cdBar;
        }
    }
 




    public void Stop(Transform ballPoint) {
        started = false;
        transform.position = ballPoint.position;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ResetSlider();
    }


}
