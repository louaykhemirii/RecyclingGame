using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iconClick : MonoBehaviour {

	private GameObject bar, icon, minus, add;
	// Use this for initialization
	void Start () {
		bar = GameObject.Find ("bar");
		icon = GameObject.Find ("tools");
		minus = GameObject.Find ("minus");
		add = GameObject.Find ("add");
		bar.SetActive (false);
	}

	void OnMouseDown()
	{
		if (bar.activeSelf == true) {
			bar.SetActive (false);
			icon.GetComponent<SpriteRenderer> ().sprite = add.GetComponent<SpriteRenderer> ().sprite;
			if (buyHouse.info.activeSelf == true)
				buyHouse.info.SetActive (false);
		} else {
			bar.SetActive (true);
			icon.GetComponent<SpriteRenderer> ().sprite = minus.GetComponent<SpriteRenderer> ().sprite;
		}
	}
}
