using UnityEngine;
using System.Collections;

public class Ctime : MonoBehaviour {
    public int test;
    //public string layerName;
    public GameObject objectName;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider c)
    {
        string layerName = LayerMask.LayerToName(c.gameObject.layer);
        //string objectName = GameObject.Find;
        test -= 1;


        if (c.gameObject.tag == "jump") return;

        //if ( layerName == "road1 (sectionS1)")
        //if (layerName == "sectionS1 (road1)")
        if (layerName == "road1/sectionS1")
        {
            test += 1;
        }









    }





    }
