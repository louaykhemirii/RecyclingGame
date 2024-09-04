using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getMoney : MonoBehaviour {
	private string Tag;
	private bool flag;
	// Use this for initialization
	void Start () {
		Tag = this.gameObject.tag;
		flag = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(flag){
			int coin = int.Parse(buyHouse.coin_num.text);
			switch (Tag) {
			case "paper":
				coin += 1;
				break;
			case "plastic":
				coin += 2;
				break;
			case "clothes":
				coin += 4;
				break;
			}
			buyHouse.coin_num.text = coin.ToString ();
			flag = false;
			StartCoroutine (_wait (1f));
		}
	}

	IEnumerator _wait(float time){
		yield return new WaitForSeconds(time);
		flag = true;
	}
}
