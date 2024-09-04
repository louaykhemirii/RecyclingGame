using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objCollision : MonoBehaviour {

	private Vector3 dir, tmp;
	public bool flag, detect;
	// Use this for initialization
	void Start () {
		float x = Random.Range (-4f, 4f);
		float y = Random.Range (-4f, 4f);
		while (x > -2 && x < 2)
			x = Random.Range (-4f, 4f);
		while (y > -2 && y < 2)
			y = Random.Range (-4f, 4f);
		dir = new Vector3 (x, y, 0);
		flag = true;
		detect = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (flag) {
			flag = false;
			StartCoroutine (_move (0.05f));
		}
		if (shoot.destroyAll) {
			GameObject.Find ("Game").GetComponent<shoot> ().destroy (this.gameObject);
		}
	}

	IEnumerator _move(float time){
		yield return new WaitForSeconds(time);
		if (transform.position.x <= 230f || transform.position.x >= 310f) {
			tmp = dir;
			dir = new Vector3 (-1 * tmp.x, tmp.y, tmp.z);
		}
		if (transform.position.y <= -70f || transform.position.y >= 35f) { 
			tmp = dir;
			dir = new Vector3 (tmp.x, -1 * tmp.y, tmp.z);	
		}
		transform.position += dir;
		flag = true;
	}
		

	void OnMouseDown(){
		GameObject.Find ("clothes_1").GetComponent<AudioSource> ().Play ();
		TextMesh tmp = GameObject.Find ("point").GetComponent<TextMesh> ();
		int point = int.Parse(tmp.text);
		if (this.gameObject.tag == shoot.title) {
			point += 10;
			tmp.text = point.ToString ();
		}
		else {
			shoot.heart -= 1;
			calculate.error++;
			string errorName = "";
			switch (this.gameObject.tag) {
			case "paper":
				errorName = "廢紙類";
				break;
			case "plastic":
				errorName = "塑膠類";
				break;
			case "clothes":
				errorName = "舊衣回收";
				break;
			case "other":
				errorName = "一般垃圾";
				break;
			}
			switch (calculate.error) {
			case 1: 
				calculate.wrong1.GetComponent<SpriteRenderer> ().sprite = this.gameObject.GetComponent<SpriteRenderer> ().sprite;
				calculate.error1.GetComponent<TextMesh> ().text = errorName;
				break;
			case 2:
				calculate.wrong2.GetComponent<SpriteRenderer> ().sprite = this.gameObject.GetComponent<SpriteRenderer> ().sprite;
				calculate.error2.GetComponent<TextMesh> ().text = errorName;
				break;
			case 3:
				calculate.wrong3.GetComponent<SpriteRenderer> ().sprite = this.gameObject.GetComponent<SpriteRenderer> ().sprite;
				calculate.error3.GetComponent<TextMesh> ().text = errorName;
				break;
			}
			switch (shoot.heart) {
			case 0:
				shoot.heart1.GetComponent<SpriteRenderer> ().color -= new Color (0f, 0f, 0f, 0.8f);
				GameObject.Find ("Game").GetComponent<shoot> ().gameEnd ();
				break;
			case 1:
				shoot.heart2.GetComponent<SpriteRenderer> ().color -= new Color (0f, 0f, 0f, 0.8f);
				break;
			case 2:
				shoot.heart3.GetComponent<SpriteRenderer> ().color -= new Color (0f, 0f, 0f, 0.8f);
				break;
			}
		}
		GameObject.Find ("Game").GetComponent<shoot> ().destroy (this.gameObject);
	}
}
