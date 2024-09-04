using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

	private static GameObject game, timeBar, calculate_f;
	private bool flag, end, timeOut, kill;
	private static string [] objName = {"paper_1", "paper_2", "paper_3", "paper_4", "plastic_1", "plastic_2", "plastic_3", "clothes_1", "clothes_2", "clothes_3", "other_1", "other_2", "other_3", "other_4", "other_5"};
	private float startTime, currTime;

	public static GameObject heart1, heart2, heart3, Title, paperTitle, clothesTitle, plasticTitle;
	public static int numPaper, numPlastic, numClothes, numOther, heart, num;
	public static string title;
	public static bool destroyAll;

	void Start(){
		timeBar = GameObject.Find ("timeBar");
		calculate_f = GameObject.Find ("calculate");
		heart1 = GameObject.Find ("heart1");
		heart2 = GameObject.Find ("heart2");
		heart3 = GameObject.Find ("heart3");
		Title = GameObject.Find ("title");
		paperTitle = GameObject.Find ("paperTitle");
		clothesTitle = GameObject.Find ("clothesTitle");
		plasticTitle = GameObject.Find ("plasticTitle");

		destroyAll = false;
		end = false;
		timeOut = false;
		kill = false;
		heart = 3;
	}

	void Update() {
		if (flag && (currTime - startTime) > 10f) {
			flag = false;
			timeOut = true;
			destroyAll = true;
		}
		if (flag && (currTime - startTime) <= 10f) {
			flag = false;
			currTime = Time.time;
			timeBar.transform.position -= new Vector3 (0.37f, 0f, 0f);
			StartCoroutine (_time (0.01f));
		}
		if (end && calculate_f.transform.position.y > 0f) {
			end = false;
			calculate.showRank = true;
		}
		if (end && calculate_f.transform.position.y <= 0f) {
			end = false;
			calculate_f.transform.position += new Vector3 (0f, 10f, 0f);
			StartCoroutine (_end (0.01f));
		}
	}

	IEnumerator _time(float time){
		yield return new WaitForSeconds(time);
		if (kill)
			flag = false;
		else
			flag = true;
	}

	public void gameEnd(){
		kill = true;
		destroyAll = true;
		calculate.error = 0;
		TextMesh score = GameObject.Find ("score").GetComponent<TextMesh> ();
		TextMesh point = GameObject.Find ("point").GetComponent<TextMesh> ();
		score.text = point.text;
		point.text = "0";

		int money = int.Parse (score.text);
		money /= 10;
		calculate.money = money;
		calculate.rank_f.SetActive (false);
		GameObject.Find ("money_num").GetComponent<TextMesh> ().text = money.ToString ();

		heart = 3;
		end = true;
		heart1.GetComponent<SpriteRenderer> ().color += new Color (0f, 0f, 0f, 0.8f);
		heart2.GetComponent<SpriteRenderer> ().color += new Color (0f, 0f, 0f, 0.8f);
		heart3.GetComponent<SpriteRenderer> ().color += new Color (0f, 0f, 0f, 0.8f);
	}

	IEnumerator _end(float time){
		yield return new WaitForSeconds(time);
		end = true;
	}

	public void gameStart(){
		destroyAll = false;
		kill = false;

		timeBar.transform.position = new Vector3 (272f, 54.4f, -6f);
		startTime = Time.time;
		flag = true;
		numPaper = numPlastic = numClothes = numOther = 0;
		game = GameObject.Find ("Game");
		num = Random.Range (0, 3);

		generator (4 * num);
		generator (4 * num);
		for (int i = 2; i < 10; i++) {
			generator (-1);
		}
		Sprite tmp = new Sprite ();
		switch (num) {
		case 0:
			title = "paper";
			tmp = paperTitle.GetComponent<SpriteRenderer> ().sprite;
			break;
		case 1:
			title = "plastic";
			tmp = plasticTitle.GetComponent<SpriteRenderer> ().sprite;
			break;
		case 2:
			title = "clothes";
			tmp = clothesTitle.GetComponent<SpriteRenderer> ().sprite;
			break;
		}
		Title.GetComponent<SpriteRenderer> ().sprite = tmp;
		Title.transform.localScale = new Vector3 (2f, 2f, 2f);
	}

	static void generator (int ctrl) {
		int ptr = Random.Range (0, 14);

		if (ctrl >= 0)
			ptr = ctrl;

		if (ptr <= 3)
			numPaper++;
		else if (ptr <= 6)
			numPlastic++;
		else if (ptr <= 9)
			numClothes++;
		else
			numOther++;

		GameObject model = GameObject.Find (objName[ptr]);
		float x = Random.Range (260f, 280f);
		float y = Random.Range (-40f, 0f);
		GameObject ball = Instantiate (model, new Vector3(x, y, -5f), new Quaternion (0, 0, 0, 0));
		ball.transform.parent = game.transform;
		ball.transform.localScale = new Vector3 (0.5f, 0.5f, 1.0f);
		ball.AddComponent<objCollision>();
	}

	public void destroy(GameObject obj) {
		switch (obj.tag.ToString ()) {
		case "paper": 
			numPaper--;
			break;
		case "plastic":
			numPlastic--;
			break;
		case "clothes":
			numClothes--;
			break;
		case "other":
			numOther--;
			break;
		}
		Destroy (obj);
		if ((numPaper == 0 && title == "paper")
		   || (numPlastic == 0 && title == "plastic")
		   || (numClothes == 0 && title == "clothes")) {
			destroyAll = true;
		}
		if (!destroyAll) generator (-1);
		else {
			if (kill) return;
			else if (timeOut) {
				if ((numPaper + numPlastic + numOther + numClothes) == 0)
					gameStart ();
			}
			else
				restart ();
		}

	}

	void restart() {
		if ((numPaper + numPlastic + numOther + numClothes) == 0) {
			num = Random.Range (0, 3);
			generator (num * 4);
			generator (num * 4);
			for (int i = 2; i < 10; i++)
				generator (-1);
			Sprite tmp = new Sprite ();
			switch (num) {
			case 0:
				title = "paper";
				tmp = paperTitle.GetComponent<SpriteRenderer> ().sprite;
				break;
			case 1:
				title = "plastic";
				tmp = plasticTitle.GetComponent<SpriteRenderer> ().sprite;
				break;
			case 2:
				title = "clothes";
				tmp = clothesTitle.GetComponent<SpriteRenderer> ().sprite;
				break;
			}
			Title.GetComponent<SpriteRenderer> ().sprite = tmp;
			Title.transform.localScale = new Vector3 (2f, 2f, 2f);
			destroyAll = false;
		}
	}
}
