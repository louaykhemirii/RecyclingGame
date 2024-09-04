using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseInfo : MonoBehaviour {

	public static GameObject mainCamera, gameCamera, animationCamera, greender;
	// Use this for initialiation
	void Start () {
		mainCamera = GameObject.Find("Main Camera");
		gameCamera = GameObject.Find("Game Camera");
		greender = GameObject.Find ("greender");
		greender.SetActive (false);
		mainCamera.SetActive (false);
		gameCamera.SetActive (false);

	}

	void OnMouseDown() {
		if (greender.activeSelf)
			greender.SetActive (false);
		else
			greender.SetActive (true);
	}
}
