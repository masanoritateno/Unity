using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Clife : MonoBehaviour {
	[SerializeField]
	public int lifetext = 0;


	void Start () {
	}

	public void AddPoint (int life) {
		lifetext = life;
		GetComponent<Text>().text = "LIFE: " + lifetext.ToString();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
