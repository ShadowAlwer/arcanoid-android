using Assets.Scripts.Consts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour {

    public PowerUp type;

    //public float speed=200f;
	// Use this for initialization
	void Start () {
        //GetComponent<Rigidbody2D>().velocity =new Vector2 (0,-speed);

        GameObject[] balls=GameObject.FindGameObjectsWithTag(Tags.BALL);
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            foreach (GameObject ball in balls)
            {
                Physics2D.IgnoreCollision(collider, ball.GetComponent<Collider2D>());
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
       
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Tags.BOTTOM_WALL)
        {
            Debug.Log("PowerUP Bottom hit");
            Destroy(gameObject);
        }
        else
        {
            //if (collision.gameObject.tag == Tags.BALL)
            //{
            //    Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            //}
        }
    }

}
