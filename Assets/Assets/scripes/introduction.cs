using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introduction : MonoBehaviour {

	public static GameObject intro, paperIntro, plasticIntro, clothesIntro;
	public static string lastName, lastTag;

	// Use this for initialization
	void Start () {
		paperIntro = GameObject.Find ("paperIntro");
		plasticIntro = GameObject.Find ("plasticIntro");
		clothesIntro = GameObject.Find ("clothesIntro");
		intro = GameObject.Find ("intro");

		intro.SetActive (false);
	}
}
