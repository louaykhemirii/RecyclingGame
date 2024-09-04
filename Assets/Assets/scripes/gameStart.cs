using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStart : MonoBehaviour {
	private GameObject gameMap;

	void Start() {
		gameMap = GameObject.Find ("Game");
	}

	void OnMouseDown(){
		if (this.gameObject.tag == "greender") {
			houseInfo.mainCamera.SetActive (false);
			houseInfo.gameCamera.SetActive (true);
			houseInfo.greender.SetActive (false);
			gameMap.GetComponent<shoot> ().gameStart ();
			shoot.heart = 3;
		}
	}
}
