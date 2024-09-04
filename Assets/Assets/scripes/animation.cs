using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour {

	private GameObject animationCamera, tmp;
	bool flag = false, play = true;

	// Use this for initialization
	void Start () {
		animationCamera = GameObject.Find ("Animation Camera");	
		tmp = GameObject.Find ("4");
	}
	
	// Update is called once per frame
	void Update () {
		if (flag && tmp.GetComponent<SpriteRenderer> ().color.a < 0f) {
			houseInfo.mainCamera.SetActive (true);
			animationCamera.SetActive (false);
			tmp.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0f);
			start.sflag = true;
		}
		if (flag && tmp.GetComponent<SpriteRenderer> ().color.a > 0f) {
			flag = false;
			StartCoroutine (_wait (0.01f, tmp));
		}

		if (play && video.click == 1) {
			play = false;
			StartCoroutine (_go (5f));
		}

		if (play && video.click == 2) {
			GameObject.Find ("2").GetComponent<AudioSource> ().Play ();
			play = false;
			StartCoroutine (_go (4f));
		}

		if (play && video.click == 3) {
			play = false;
			StartCoroutine (_go (4f));
		}
		if (play && video.click == 4) {
			GameObject.Find ("4").GetComponent<AudioSource> ().Play ();
			play = false;
			StartCoroutine (_wait (3f, GameObject.Find("4")));
		}
	}
		
	IEnumerator _wait(float time, GameObject tmp){
		yield return new WaitForSeconds(time);
		tmp.GetComponent<SpriteRenderer> ().color -= new Color (0f, 0f, 0f, 0.01f);
		flag = true;
	}

	IEnumerator _go(float time){
		yield return new WaitForSeconds(time);
		animationCamera.transform.position += new Vector3 (125, 0, 0);
		video.click++;
		play = true;
	}
}
