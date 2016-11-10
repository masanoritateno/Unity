using UnityEngine;
using System.Collections;

public class Cenimy : MonoBehaviour {
	public float xspeed = 10f;
	public float zspeed = 5f;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().velocity = new Vector3 (xspeed, 0, 0);
		GetComponent<Rigidbody> ().angularVelocity = new Vector3 (0, 0, zspeed);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x >= 34) {
			GetComponent<Rigidbody> ().velocity = new Vector3 (-xspeed, 0, 0);
		}
		if (transform.position.x <= -34) {
			GetComponent<Rigidbody> ().velocity = new Vector3 (xspeed, 0, 0);
		}
	}
}
