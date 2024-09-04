using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class video : MonoBehaviour {

	GameObject logo;
	public static int click;

	// Use this for initialization
	void Start () {
		logo = GameObject.Find ("video");
		StartCoroutine (_wait (6f, logo));
	}

	IEnumerator _wait(float time, GameObject tmp){
		yield return new WaitForSeconds(time);
		GameObject.Find ("Animation Camera").transform.position += new Vector3 (125f, 0f, 0f);
		GameObject.Find ("1").GetComponent<AudioSource> ().Play ();
		click++;
	}
}
