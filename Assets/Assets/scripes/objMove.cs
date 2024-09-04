using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class objMove : MonoBehaviour {

	int depth;
	private Vector3 initPos;
	private GameObject map;
	private int i;
	public static bool paperBuy = false;
	public static bool clothesBuy = false;
	public static bool plasticBuy = false;
	public static bool isBuy = false;
	public static string curr = "";


	void Start()
	{
		map = GameObject.Find ("Map");
		depth = 5;
		i = 0;
	}

	Vector3 prePos;
	void OnMouseDown()
	{
		if (introduction.intro.activeSelf)
			introduction.intro.SetActive (false);
		initPos = this.transform.position;
		Vector3 mouse = Input.mousePosition;
		mouse.z = depth;
		prePos = Camera.main.ScreenToWorldPoint (mouse);
		string pre = curr;
		curr = this.tag.ToString ();
		switch (curr) {
		case "paper":
			if (!paperBuy) {
				setInfo ("paper");
				if (buyHouse.info.activeSelf == false)
					buyHouse.info.SetActive (true);
				else if (curr == pre)
					buyHouse.info.SetActive (false);
			}
			break;
		case "clothes":
			if (!clothesBuy) {
				setInfo ("clothes");
				if (buyHouse.info.activeSelf == false)
					buyHouse.info.SetActive (true);
				else if (curr == pre)
					buyHouse.info.SetActive (false);
			}
			break;
		case "plastic":
			if (!plasticBuy) {
				setInfo ("plastic");
				if (buyHouse.info.activeSelf == false)
					buyHouse.info.SetActive (true);
				else if (curr == pre)
					buyHouse.info.SetActive (false);
			}
			break;
		}
	}

	void OnMouseDrag()
	{
		curr = this.tag.ToString ();
		if (!clothesBuy && !paperBuy && !plasticBuy)
			return;
		else if (clothesBuy && curr != "clothes")
			return;
		else if (paperBuy && curr != "paper")
			return;
		else if (plasticBuy && curr != "plastic")
			return;
		buyHouse.info.SetActive (false);
		Vector3 mouse = Input.mousePosition;
		mouse.z = depth;
		Vector3 newPos = Camera.main.ScreenToWorldPoint (mouse);
		Vector3 offset = newPos - prePos;
		transform.position += offset;
		prePos = Camera.main.ScreenToWorldPoint (mouse);
	}

	void OnMouseUp()
	{
		string curr = this.tag.ToString ();

		if (!clothesBuy && !paperBuy && !plasticBuy)
			return;
		else if (clothesBuy && curr != "clothes")
			return;
		else if (paperBuy && curr != "paper")
			return;
		else if (plasticBuy && curr != "plastic")
			return;
		

		switch (curr) {
		case "clothes":
			clothesBuy = false;
			curr = "Clothes";
			break;
		case "paper":
			paperBuy = false;
			curr = "Paper";
			break;
		case "plastic":
			plasticBuy = false;
			curr = "Plastic";
			break;
		}
		GameObject model = GameObject.Find (curr);
		GameObject newHouse = Instantiate (model, transform.position, new Quaternion (0, 0, 0, 0));
		newHouse.transform.localScale = new Vector3 (3.0f, 3.0f, 1.0f);
		newHouse.transform.position += new Vector3 (0f, 0f, 1f);
		newHouse.transform.parent = map.transform;
		newHouse.AddComponent<getMoney> ();
		newHouse.name = curr + i.ToString ();
		i++;
		this.transform.position = initPos;
	}

	void setInfo(string Image) {
		bool state = buyHouse.info.activeSelf;
		buyHouse.info.SetActive (true);
		Sprite tmp = new Sprite();
		switch (Image) {
		case "clothes":
			tmp = GameObject.Find("info_clothes").GetComponent<SpriteRenderer> ().sprite;
			break;
		case "paper":
			tmp = GameObject.Find("info_paper").GetComponent<SpriteRenderer> ().sprite;
			break;
		case "plastic":
			tmp = GameObject.Find("info_plastic").GetComponent<SpriteRenderer> ().sprite;
			break;
		}
		buyHouse.info.GetComponent<SpriteRenderer> ().sprite = tmp;
		buyHouse.info.SetActive (state);
	}
		
}