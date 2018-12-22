using Assets.Scripts.Consts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockeController : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,speed);

        GameObject[] balls = GameObject.FindGameObjectsWithTag(Tags.BALL);
        GameObject[] powerups = GameObject.FindGameObjectsWithTag(Tags.POWER_UP);
        GameObject[] hardblocks = GameObject.FindGameObjectsWithTag(Tags.HARD_BLOCK);
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            foreach (GameObject ball in balls)
            {
                Physics2D.IgnoreCollision(collider, ball.GetComponent<Collider2D>());
            }
            foreach (GameObject powerup in powerups)
            {
                Physics2D.IgnoreCollision(collider, powerup.GetComponent<Collider2D>());
            }
            foreach (GameObject block in hardblocks)
            {
                Physics2D.IgnoreCollision(collider, block.GetComponent<Collider2D>());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Tags.BLOCK)
        {
            FindObjectOfType<ScoreGUIController>().AddScore(collision.gameObject.GetComponent<BlockController>().GetPointValue());
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == Tags.WALL)
        {
            Destroy(gameObject);
        }
    }
}
