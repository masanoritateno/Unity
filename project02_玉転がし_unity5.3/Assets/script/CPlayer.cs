using UnityEngine;
using System.Collections;

public class CPlayer : MonoBehaviour {
    public Rigidbody rb;
    public int jump = 0;
    

    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        
	
	}

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "jump")
        {
            rb.velocity = new Vector3(rb.velocity.x, 10, rb.velocity.z);
            jump += 1;
        }
        
    }



    }
