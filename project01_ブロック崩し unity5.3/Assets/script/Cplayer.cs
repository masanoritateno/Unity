using UnityEngine;
using System.Collections;

public class Cplayer : MonoBehaviour {
	[SerializeField]
	private Vector3 pos;
	[SerializeField]
	private Vector3 WorldPointPos;
	[SerializeField]
	private float posx;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {



		//マウス位置座標をVector3で取得
		pos = Input.mousePosition;
		pos.z = 140f;
		posx = Input.mousePosition.x;

		// マウス位置座標をスクリーン座標からワールド座標に変換する
		WorldPointPos = Camera.main.ScreenToWorldPoint(pos);
//		transform.position = WorldPointPos;
		//WorldPointPos = pos;
//		WorldPointPos.x -= 105;
		WorldPointPos.y = -55.0f;
		WorldPointPos.z = 0.0f;

		if(WorldPointPos.x > 32){
			WorldPointPos.x = 32;
		}
		if(WorldPointPos.x < -32){
			WorldPointPos.x = -32;
		}


		// ワールド座標をPlayer位置へ変換
		transform.position = WorldPointPos;
	}

//	void FixedUpdate (){
//		if (Input.GetKey ("right")) {
//			transform.position += transform.right * speed * Time.deltaTime;
//		}
//		if (Input.GetKey ("left")) {
//			transform.position -= transform.right * speed * Time.deltaTime;
//		}
//	}

}
