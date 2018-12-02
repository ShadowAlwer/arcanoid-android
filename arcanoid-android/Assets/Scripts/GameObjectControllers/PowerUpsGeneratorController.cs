using Assets.Scripts.Consts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsGeneratorController : MonoBehaviour {

    public GameObject[] powerUpsPrefabs;
    public float deltaTime = 5f;
    public float chance = 0.0001f;

    BallController ball;
    float generationArea = 285f;
    float lastGeneration;
    
	// Use this for initialization
	void Start () {
       ball= GameObject.FindGameObjectWithTag(Tags.BALL).GetComponent<BallController>();
       lastGeneration = Time.time;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (ball.started)
        {
            if (lastGeneration + deltaTime < Time.time)
            {
                if (Random.Range(0f, 1f) < chance)
                {
                    if (powerUpsPrefabs.Length > 0)
                    {
                        int index = (int)Random.Range(0f, powerUpsPrefabs.Length - 0.5f);
                        GameObject powerUp = Instantiate(powerUpsPrefabs[index]);
                        Vector3 tmp = new Vector3(transform.position.x + Random.Range(-generationArea, generationArea), transform.position.y, 0);
                        powerUp.transform.position = tmp;
                        lastGeneration = Time.time;
                    }
                }
            }
        }
	}
}
