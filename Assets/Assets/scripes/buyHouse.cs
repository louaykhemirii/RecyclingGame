using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyHouse : MonoBehaviour {

	public static  GameObject map, info;
	public static TextMesh coin_num;

	// Use this for initialization
	void Start () {
		map = GameObject.Find ("Map");
		info = GameObject.Find ("info");
		coin_num = GameObject.Find("coin_num").GetComponent<TextMesh>();

		info.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		int coin = int.Parse (coin_num.text);
		bool noMoney = false;
		switch (objMove.curr) {
		case "clothes":
			if (coin >= 2000) {
				coin -= 2000;
				objMove.clothesBuy = true;
			} else
				noMoney = true;
			break;
		case "paper":
			if (coin >= 1000) {
				coin -= 1000;
				objMove.paperBuy = true;
			} else
				noMoney = true;
			break;
		case "plastic":
			if (coin >= 4000) {
				coin -= 4000;
				objMove.plasticBuy = true;
			} else
				noMoney = true;
			break;
		}
		if (noMoney) {
			map.GetComponent<mapMove> ().sendAlert ("金錢不足!");
			noMoney = false;
		}
		coin_num.text = coin.ToString ();
		info.SetActive (false);
	}
}
