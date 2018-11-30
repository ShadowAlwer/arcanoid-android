using Assets.Scripts.Consts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUpMenager : MonoBehaviour {

    public float platformPowerUpDuration = 5f;

    public bool isPlatformPowerUpActive = false;

    public float widthAdded=200f;

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
                break;
            case PowerUp.Rockets:
                break;          
        }
    }


    private void ApplayPlatformPowerUp()
    {
        Debug.Log("Applaing PlatformPowerUp");
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
}
