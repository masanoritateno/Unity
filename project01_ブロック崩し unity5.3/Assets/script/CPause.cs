using UnityEngine;
using System.Collections;

public class CPause : MonoBehaviour {

	public void ButtonPush()
	{
		if (Time.timeScale == 1.0F)
			Time.timeScale = 0;
		else
			Time.timeScale = 1.0F;
	}


}
