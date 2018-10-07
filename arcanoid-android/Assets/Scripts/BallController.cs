using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float speed = 10f;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Rigidbody2D>().velocity.magnitude != speed) {
            GetComponent<Rigidbody2D>().velocity=Vector2.ClampMagnitude(GetComponent<Rigidbody2D>().velocity, speed);
        }
    }
}
