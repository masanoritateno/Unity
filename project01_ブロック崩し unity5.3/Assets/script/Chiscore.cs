using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Chiscore : MonoBehaviour {
	[SerializeField]
	public static int hiscore = 0;



	// Use this for initialization
	void Start () {

		//初期スコア(0点)を表示
		GetComponent<Text>().text = "HiScore: " + hiscore.ToString();
	}

	public void AddPoint (int point) {
		if(hiscore < point){
		hiscore = point;
		GetComponent<Text>().text = "HiScore: " + hiscore.ToString();
		}
	}


	// Update is called once per frame
	void Update () {

	}
}