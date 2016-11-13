using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class master : MonoBehaviour {
    [SerializeField]
    private Rigidbody rb;

    //-----------camera追従用-------------------------
    [SerializeField]
    GameObject Player;
    [SerializeField]
    GameObject mainCamera;

    //-----------操作input関連-------------------------
    [SerializeField]
    private Vector3 startPos;
    [SerializeField]
    private Vector3 pos;
    [SerializeField]
    private Vector3 differencePos;//差分(要yz入れ替え)
    [SerializeField]
    private double rangePos;//距離
    public float rangePosMin = 1f;//最小距離
    public float rangePosMax = 200f;//最大距離

    //----エフェクト用------
    [SerializeField]
    private Vector3 worldPos;

    //-----------jump-------------------------
    public int jump = 0;



    //-----------操作output関連-------------------------


    //-----------score関連-------------------------
    public float score;
    public float hiscore;


    //------------シーン切り替え用------------------------
    public static int scene;

    //------------アニメーション------------------------
    public int sceneA;


    //------------中継地点------------------------
    public int section;


    //------------------------------------




    void Start () {
        rb = GetComponent<Rigidbody>();
        
        Player = GameObject.Find("Player");
        //Player = GameObject.Find("unitychan");
        mainCamera = GameObject.Find("Main Camera");
        section = 0;



    }


    void Update () {

        pos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(pos);

        score += Time.deltaTime;







        //-----------操作input関連-------------------------
        if (Input.GetMouseButtonDown(0))
        {
            startPos = pos;


            if (Input.GetMouseButtonUp(0))
            {
                Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                

            }
        }//if (Input.GetMouseButtonDown(0))ここまで


        if (Input.GetMouseButton(0))

        {
            differencePos = pos - startPos;


            rangePos = Mathf.Sqrt((differencePos.x * differencePos.x) + (differencePos.y * differencePos.y));


            if(rangePosMin <= rangePos)
            {
                differencePos.x = differencePos.x / 10;
                differencePos.y = differencePos.y / 10;
                differencePos.z = differencePos.y;
                //differencePos.y = 0f;
                differencePos.y = Player.GetComponent<Rigidbody>().velocity.y;


                Player.GetComponent<Rigidbody>().velocity = differencePos;
                //キャラクターを動かす場合
                //Player.GetComponent<Rigidbody>().transform.Translate(differencePos, Space.World);



            }
            else { Player.GetComponent<Rigidbody>().velocity = new Vector3(0, Player.GetComponent<Rigidbody>().velocity.y, 0); }


        }//if (Input.GetMouseButton(0))ここまで




        //-----------camera追従用-------------------------
        mainCamera.transform.position = new Vector3(Player.transform.position.x, (Player.transform.position.y) + 5, (Player.transform.position.z) - 10);

    }//voidUpdateここまで












        





}
