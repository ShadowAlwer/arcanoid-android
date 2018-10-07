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

        float direction = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * direction * speed;
	}
}
