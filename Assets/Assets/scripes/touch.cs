using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour {
	private bool upgrade;

	void Start() {
		upgrade = true;
	}

	void OnMouseDown() {
		if (upgrade && this.gameObject.tag != "upgrade") {
			if (buyHouse.info.activeSelf == true)
				buyHouse.info.SetActive (false);
			if (introduction.intro.activeSelf == true)
				introduction.intro.SetActive (false);
			else {
				introduction.intro.SetActive (true);
				Sprite tmp = new Sprite ();
				switch (this.gameObject.tag) {
				case "paper":
					tmp = introduction.paperIntro.GetComponent<SpriteRenderer> ().sprite;
					break;
				case "plastic":
					tmp = introduction.plasticIntro.GetComponent<SpriteRenderer> ().sprite;
					break;
				case "clothes":
					tmp = introduction.clothesIntro.GetComponent<SpriteRenderer> ().sprite;
					break;
				}
				introduction.lastName = this.gameObject.name;
				introduction.lastTag = this.gameObject.tag;
				introduction.intro.GetComponent<SpriteRenderer> ().sprite = tmp;
				introduction.intro.SetActive (true);
			}
		} else if (upgrade && this.gameObject.tag == "upgrade") {
			int money = int.Parse (buyHouse.coin_num.text);
			bool noMoney = false;
			switch (introduction.lastTag) {
			case "paper":
				if (money >= 2000)
					money -= 2000;
				else
					noMoney = true;
				break;
			case "plastic":
				if (money >= 5800)
					money -= 5800;
				else
					noMoney = true;
				break;
			case "clothes":
				if (money >= 3000)
					money -= 3000;
				else
					noMoney = true;
				break;
			}
			buyHouse.coin_num.text = money.ToString ();
			introduction.intro.SetActive (false);
			if (noMoney)
				GameObject.Find ("Map").GetComponent<mapMove> ().sendAlert ("金錢不足");
			else
				GameObject.Find(introduction.lastName).GetComponent<touch>().upgrade = false;
		}
	}
}
