using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class mapMove : MonoBehaviour {

	int depth;
	public TextMesh alert;
	public static bool canMove = false;

	void Start()
	{
		alert = GameObject.Find ("alert").GetComponent<TextMesh>();
		alert.gameObject.SetActive (false);
		depth = 10;
	}

	Vector3 prePos;
	void OnMouseDown()
	{
		if (houseInfo.greender.activeSelf)
			houseInfo.greender.SetActive (false);
		if (introduction.intro.activeSelf)
			introduction.intro.SetActive (false);
		if(canMove){
		Vector3 mouse = Input.mousePosition;
		mouse.z = depth;
		prePos = Camera.main.ScreenToWorldPoint (mouse);
		if (buyHouse.info.activeSelf == true)
			buyHouse.info.SetActive (false);	
		}
	}

	void OnMouseDrag()
	{
		if(canMove) {
		Vector3 mouse = Input.mousePosition;
		mouse.z = depth;
		Vector3 newPos = Camera.main.ScreenToWorldPoint (mouse);
		Vector3 offset = newPos - prePos;
		transform.position += offset;
		if (transform.position.x <= -120)
			transform.position = new Vector3 (-120, transform.position.y, transform.position.z);
		if (transform.position.x >= 20) 
			transform.position = new Vector3 (20, transform.position.y, transform.position.z);
		if (transform.position.y <= -20)
			transform.position = new Vector3 (transform.position.x, -20, transform.position.z);
		if (transform.position.y >= 20)
			transform.position = new Vector3 (transform.position.x, 20, transform.position.z);
		prePos = Camera.main.ScreenToWorldPoint (mouse);
		}
	}

	public void sendAlert (string input) {
		alert.gameObject.SetActive(true);
		alert.GetComponent<TextMesh>().text = input;
		StartCoroutine (_wait ((float) 1));
	}

	IEnumerator _wait(float time){
		yield return new WaitForSeconds(time);
		alert.gameObject.SetActive(false);
	}
}