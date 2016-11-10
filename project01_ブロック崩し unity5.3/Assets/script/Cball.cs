using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cball : MonoBehaviour {
	public static float xspeed = 50f;
	public static float yspeed = 50f;
	[SerializeField]
	private int start = 0;
	public Rigidbody rb;
	//-------------------スコア&ライフ処理用-------------------
	GameObject[] targetObjects;
	public int targetNum;
	[SerializeField]
	private static int point = 0;
	public int apoint = 0;
	//GameObject[] game1Object;
	//public int game1Num;
	public GameObject scoreGUI;
	public GameObject hiscoreGUI;
	public GameObject lifeGUI;
	public static int scene = 0;
	public int ascene = 0;
	public static int life = 5;
	public int alife =0;
	//-------------------移動処理用-------------------
	[SerializeField]
	private Vector3 pos;
	[SerializeField]
	private Vector3 WorldPointPos;
	//-------------------エラー処理用-------------------
	[SerializeField]
	private int errorpoint = 0;
	[SerializeField]
	private int error = 0;
	[SerializeField]
	private int errorlife = 0;
	//----------------上限速度用--------------------------
	[SerializeField]
	private float maxV = 300f;
	[SerializeField]
	private float maxVV;
	public int chackmaxV = 0;
    //----------------下限速度用--------------------------
    [SerializeField]
    private float minV = 30f;
    [SerializeField]
    private float minVV;
    public int chackminV = 0;
    //----------------ループ時--------------------------
//    private float minXY = 3f;
//    public int chackminX = 0;
//    private float minY = 30f;
//    public int chackminY = 0;
    public int chackloop = 0;
    public int button =0;
    public GameObject button1;
//	public GameObject buttontext;



    // Use this for initialization
    void Start () {
		targetObjects = GameObject.FindGameObjectsWithTag ("target");
		targetNum = targetObjects.Length;
		//-----ステージ1かどうかを判別する
		//game1Object = GameObject.FindGameObjectsWithTag ("game1");
		//game1Num = game1Object.Length;
		//if (game1Num == 1) {point = 0;}
		//-----
		scoreGUI.SendMessage ("AddPoint",point);
		lifeGUI.SendMessage ("AddPoint",life);
        rb = GetComponent<Rigidbody>();
		maxVV = maxV * maxV;
		minVV = minV * minV;

        GameObject.Find("Button1").GetComponent<UnityEngine.UI.Image>().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
		if(start == 0){

			//------------------左右の移動のスクリプト---------------
			pos = Input.mousePosition;
			pos.z = 140f;
			WorldPointPos = Camera.main.ScreenToWorldPoint(pos);
			WorldPointPos.y = -52.0f;
			if(WorldPointPos.x > 32){
				WorldPointPos.x = 32;
			}
			if(WorldPointPos.x < -32){
				WorldPointPos.x = -32;
			}
			transform.position = WorldPointPos;
		}

		//----------------------ボタンを離した時にボール発射-----------------
		if (Input.GetMouseButtonUp (0)) {
			if (start == 0) {
				GetComponent<Rigidbody> ().AddForce (((transform.up) * yspeed + (transform.right) * xspeed), ForceMode.VelocityChange);
				start += 1;
			}
		}
		if (Input.GetMouseButtonUp(0)) {
			//-----------------------ゲームオーバー-------------
			if(life == 0){
				life += 5;
				scene -= scene;
				xspeed = 50;
				yspeed = 50;
				point -= point;
				SceneManager.LoadScene ("gameover");
			}

			//----------------------ステージクリア時のシーン切替---------------
			if (start == 2) {
				scene += 1;
				life += 5;
				
				if (scene == 1) {
					
					SceneManager.LoadScene ("game2");
				}
				if (scene == 2) {
					SceneManager.LoadScene ("game3");
				}
				if (scene == 3) {
					SceneManager.LoadScene ("game4");
				}
				if (scene == 4) {
					SceneManager.LoadScene ("game5");
				}
				if (scene == 5) {
					SceneManager.LoadScene ("game6");
				}
				if (scene == 6) {
					SceneManager.LoadScene ("game7");
				}
				if (scene == 7) {
					SceneManager.LoadScene ("game8");
				}
				if (scene == 8) {
					SceneManager.LoadScene ("game9");
				}
				if (scene == 9) {
					SceneManager.LoadScene ("game10");
				}
				if (scene == 10) {
					scene = 0;
					point += 150;
					xspeed += 25;
					yspeed += 25;
					SceneManager.LoadScene ("game1");
				}
			}
		}
		//---------inspectorの画面で確認するため------------------
		ascene = scene;
		apoint = point;
		alife = life;
	}


	void OnCollisionEnter(Collision other) {
		chackloop += 1;
		if (other.gameObject.tag == "target") {
			chackloop = 0;

			//-------------------ボールがブロックを消去した時の処理---------------
			GameObject.Destroy(other.gameObject);
			targetNum -= 1;
			point += 10;
			errorpoint += 10;
			scoreGUI.SendMessage ("AddPoint",point);
			hiscoreGUI.SendMessage ("AddPoint",point);



			if (targetNum == 0) {

				//ボールの動きを止める
				GetComponent<Rigidbody> ().velocity = Vector3.zero;
				//ボールを消す
				//GameObject.Destroy(this.gameObject);

				start += 1;
			}
		}
		//------------------autoゾーンにあたった時の処理----------------
		if (other.gameObject.tag == "outzone") {
			life -= 1;
			errorlife += 1;
			lifeGUI.SendMessage ("AddPoint", life);
			if (life == 0) {
				GetComponent<Rigidbody> ().velocity = Vector3.zero;
			}
		}
		//--------------playerに当たった時chackloopを0にする------------------------
		//if (other.gameObject.tag == "Player") {	chackloop = 0;}
	}

	//--------------------上限速度-------------------------------
	void FixedUpdate(){
		// 移動速度制限処理
		Vector3 v = GetComponent<Rigidbody> ().velocity;
		//v.y = 0f;
		if (v.sqrMagnitude > maxVV) {
			v =  GetComponent<Rigidbody> ().velocity - (v.normalized * maxV);
			//v.y = 0f;
			GetComponent<Rigidbody> ().velocity -= v;
			chackmaxV += 1;
		}
        //------------------下限速度------------------------
        if(v.sqrMagnitude < minVV) {
            v = rb.velocity - (v.normalized * minV);
            rb.velocity -= v;
            chackminV += 1;
        }
        //---------------------xが少なすぎてループするとき---------------------------
//        if (rb.velocity.x < minXY)
//        {
//            if (button <= 2)
//            {
//                chackminX += 1;
//                if (chackminX >= 200)
//                {
//                    GameObject.Find("Button1").GetComponent<UnityEngine.UI.Image>().enabled = true;
//                    button = 1;
//                    button1.SendMessage("Addbutton", button);
//                    chackloop += 1;
//                }
//            }
//        }
//        else
//        {
//            chackminX = 0;
//            GameObject.Find("Button1").GetComponent<UnityEngine.UI.Image>().enabled = false;
//            button = 0;
//            button1.SendMessage("Addbutton", button);
//        }

        //---------------------chackloopが20を超えてループするとき---------------------------
		if (chackloop >= 20)
		{
			if (button <= 2)
			{
				
					GameObject.Find("Button1").GetComponent<UnityEngine.UI.Image>().enabled = true;
					button = 1;
					button1.SendMessage("Addbutton", button);
//				GameObject.Find("buttontext").GetComponent<Text>().text = "restart";
			}
		}
		else
		{
			GameObject.Find("Button1").GetComponent<UnityEngine.UI.Image>().enabled = false;
			button = 0;
			button1.SendMessage("Addbutton", button);
		}
    }

    //---------------------buttonからの返答---------------------------
    public void Addball(int buttonstate)
    {
        button = buttonstate;
        if(button == 4)
        {
            GetComponent<Rigidbody>().AddForce(((transform.up) * yspeed + (transform.right) * xspeed), ForceMode.VelocityChange);
            button = 0;
			chackloop = 0;
        }
        //rb.velocity = Vector3.zero;
    }


}
