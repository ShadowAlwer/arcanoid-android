using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuMenager : MonoBehaviour {

    public string themeToPlay = "Theme";
	// Use this for initialization
	void Start () {
        FindObjectOfType<AudioMenager>().PlayTheme(themeToPlay);
    }
}
