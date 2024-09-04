using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calculate : MonoBehaviour {

	public static GameObject score_f, rank_f, calculate_f, wrong1, wrong2, wrong3;
	public static TextMesh error1, error2, error3;
	public static bool showRank, back;
	public static int money, error;

	// Use this for initialization
	void Start () {
		rank_f = GameObject.Find ("rank_frame");
		score_f = GameObject.Find ("score_frame");
		calculate_f = GameObject.Find ("calculate");
		wrong1 = GameObject.Find ("wrong1");
		wrong2 = GameObject.Find ("wrong2");
		wrong3 = GameObject.Find ("wrong3");
		error1 = GameObject.Find ("error1").GetComponent<TextMesh> ();
		error2 = GameObject.Find ("error2").GetComponent<TextMesh> ();
		error3 = GameObject.Find ("error3").GetComponent<TextMesh> ();
		back = false;
		error = 0;
	}

	void Update() {
	}

	void OnMouseDown() {
		if (back) {
			money += int.Parse (buyHouse.coin_num.text);
			buyHouse.coin_num.text = money.ToString ();
			houseInfo.mainCamera.SetActive (true);
			houseInfo.gameCamera.SetActive (false);
			back = false;
			rank_f.SetActive (false);
			score_f.SetActive (true);
			calculate_f.transform.position = new Vector3 (272.5f, -184.9f, -6f);
		}
		if (showRank) {
			score_f.SetActive (false);
			rank_f.SetActive (true);
			back = true;
			showRank = false;
		}
	}
}
