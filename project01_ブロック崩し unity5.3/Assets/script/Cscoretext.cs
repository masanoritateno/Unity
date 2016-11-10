using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cscoretext : MonoBehaviour {
	[SerializeField]
	public int score = 0;


	void Start () {
		GetComponent<Text>().text = "Score: " + score.ToString();
	}

	public void AddPoint (int point) {
		score = point;
	GetComponent<Text>().text = "Score: " + score.ToString();
	}


	void Update () {
	}
}