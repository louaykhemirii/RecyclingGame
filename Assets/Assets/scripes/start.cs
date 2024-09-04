using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour {
	private GameObject  ufo, ufo_start;
	public static bool sflag = false;
	private bool blink = false;
	private int tmp = 0;
	// Use this for initialization
	void Start () {
		ufo = GameObject.Find ("ufo");
		ufo_start = GameObject.Find ("ufo-game start");
		ufo_start.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (sflag && ufo.transform.position.y > 15.4f) {
			sflag = false;
			StartCoroutine (_start (0.01f));
		}
		if (sflag && ufo.transform.position.y <= 15.4f) {
			sflag = false;
			blink = true;
		}
		if (blink && tmp < 3) {
			blink = false;
			ufo.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
			StartCoroutine (_blink (0.25f));
		}
		if (blink && tmp >= 3) {
			blink = false;
			ufo.SetActive (false);
			ufo_start.SetActive (true);
			mapMove.canMove = true;
		}
	}

	IEnumerator _start(float time){
		yield return new WaitForSeconds(time);
		ufo.transform.position += new Vector3 (0f, -1f, 0f);
		sflag = true;
	}
	IEnumerator _blink(float time){
		yield return new WaitForSeconds(time);
		ufo.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
		yield return new WaitForSeconds(time);
		blink = true;
		tmp += 1;
	}
}
