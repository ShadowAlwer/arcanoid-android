using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMenager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FindObjectOfType<AudioMenager>().PlayTheme("Theme");
	}
}
