using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fix : MonoBehaviour {

	// Use this for initialization
    [RuntimeInitializeOnLoadMethod]
	static void Awake ()
    {
     //        고정 192 x.1080 
     //  Screen.SetResolution(1600, 900, true);
            // 비율 예 2:3 
       Screen.SetResolution(Screen.width, (Screen.width / 16) * 9, false);
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
