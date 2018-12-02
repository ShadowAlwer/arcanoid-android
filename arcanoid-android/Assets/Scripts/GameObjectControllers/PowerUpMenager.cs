using Assets.Scripts.Consts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUpMenager : MonoBehaviour {

    public float platformPowerUpDuration = 5f;

    public bool isPlatformPowerUpActive = false;

    public float widthAdded=200f;

    public float rocketsWidth = 80f;

    public GameObject powerUpRocketPrefab;

    public GameObject powerUpBallPrefab;

    public Transform ballPoint;

    float platformPowerUpEndTime;

    Transform originalPlatformTransform;
    LevelMenager level;

    // Use this for initialization
    void Start () {
        platformPowerUpEndTime = Time.time;
        level = FindObjectOfType<LevelMenager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isPlatformPowerUpActive && Time.time > platformPowerUpEndTime) {
            ResetPlatformPowerUp();
        }

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Tags.POWER_UP)
        {
            ApplayPowerUp(collision.gameObject.GetComponent<PowerUpController>().type);
            Destroy(collision.gameObject);
        }
    }


    public void ApplayPowerUp(PowerUp type) {

        Debug.Log("Applaing PowerUp");
        switch (type) {
            case PowerUp.Platform:
                ApplayPlatformPowerUp();
                break;
            case PowerUp.Health:
                ApplayHealthPowerUp();
                break;
            case PowerUp.Balls:
                ApplayBallsPowerUp();
                break;
            case PowerUp.Rockets:
                ApplayRocketsPowerUp();
                break;          
        }
    }

    private void ApplayPlatformPowerUp()
    {
        if (!isPlatformPowerUpActive)
        {
            GameObject.FindGameObjectWithTag(Tags.PLATFORM).transform.localScale+=new Vector3(widthAdded,0,0);
            isPlatformPowerUpActive = true;          
        }
        platformPowerUpEndTime = Time.time + platformPowerUpDuration;
    }

    private void ResetPlatformPowerUp()
    {
        GameObject.FindGameObjectWithTag(Tags.PLATFORM).transform.localScale += new Vector3(-widthAdded, 0, 0);
        isPlatformPowerUpActive = false;
    }

    private void ApplayHealthPowerUp()
    {      
        if (level != null) {
            level.AddHealth();
        }
    }

    private void ApplayBallsPowerUp()
    {
        GameObject ball=Instantiate(powerUpBallPrefab);
        ball.transform.position = ballPoint.position;
    }

    private void ApplayRocketsPowerUp()
    {
        GameObject rocket1 = Instantiate(powerUpRocketPrefab);
        rocket1.transform.position = ballPoint.position+new Vector3(-rocketsWidth,0,0);
        GameObject rocket2 = Instantiate(powerUpRocketPrefab);
        rocket2.transform.position = ballPoint.position + new Vector3(rocketsWidth, 0, 0);
    }

}
