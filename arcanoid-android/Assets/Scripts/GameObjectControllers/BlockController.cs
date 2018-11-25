using Assets.Scripts.Consts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

    public int pointsValue = 50;
    public GameObject destroyEffectPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag==Tags.BALL) {
            if (destroyEffectPrefab != null) {
                GameObject destroyEffect= Instantiate(destroyEffectPrefab) as GameObject;
                destroyEffect.transform.position = this.transform.position;
                destroyEffect.transform.SetParent(transform.parent);
                destroyEffect.transform.localScale = transform.localScale;
                Destroy(destroyEffect, 2f);
            }

            FindObjectOfType<AudioMenager>().Play("Beep1");

           
            Destroy(gameObject);
        }
    }

    public int GetPointValue() {
        return pointsValue;
    }



    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
