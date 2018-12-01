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
        GameObject[] blocks = GameObject.FindGameObjectsWithTag(Tags.BLOCK);
        GameObject[] hardblocks= GameObject.FindGameObjectsWithTag(Tags.HARD_BLOCK);
        GameObject[] rockets = GameObject.FindGameObjectsWithTag(Tags.ROCKET);
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            foreach (GameObject ball in balls)
            {
                Physics2D.IgnoreCollision(collider, ball.GetComponent<Collider2D>());
            }
            foreach (GameObject block in blocks)
            {
                Physics2D.IgnoreCollision(collider, block.GetComponent<Collider2D>());
            }
            foreach (GameObject block in hardblocks)
            {
                Physics2D.IgnoreCollision(collider, block.GetComponent<Collider2D>());
            }
            foreach (GameObject rocket in rockets)
            {
                Physics2D.IgnoreCollision(collider, rocket.GetComponent<Collider2D>());
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
            Destroy(gameObject);
        }
    }

}
