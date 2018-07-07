using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePeage_Behavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.anyKeyDown)
        {
            lv_control.GetInstance.reload();
        }
       

    }
}
