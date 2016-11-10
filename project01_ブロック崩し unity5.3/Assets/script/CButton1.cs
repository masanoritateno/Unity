using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CButton1 : MonoBehaviour
{
    public int buttonstate = 0;
    public GameObject ball;
 //   public Button button3;
   // button3 = GetComponent<Button>();

    // Use this for initialization
    void Start()
    {
        //gameObject.SetActive(false);
        //GetComponent<Canvas>().enabled = false;
        
    }

    // Update is called once per frame
	//-----------buttonを連打出来ないようにする処理------------------------------
    void Update()
    {
        if(buttonstate >= 2)
        {
			if (buttonstate <= 90) {
				buttonstate += 1;
			}
        }

    }
	//------------ballからbuttonが来た時の処理-----------
    public void Addbutton(int button)
    {
        buttonstate = button;
        
        
    }

	//-------------buttonをpushした時の処理-------------------------------
    public void ButtonPush()
    {

        if (buttonstate == 1)
        {
            buttonstate = 3;
            ball.SendMessage("Addball", buttonstate);
            GameObject.Find("ball").GetComponent<UnityEngine.Rigidbody>().velocity = Vector3.zero;
		}

        if (buttonstate >= 30)
        {
            buttonstate = 4;
            ball.SendMessage("Addball", buttonstate);
            buttonstate = 0;
        }


    }
}
