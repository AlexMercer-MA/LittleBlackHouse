using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderCheck : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D tempCollider)
    {
        if (tempCollider.tag == "Player") {
            //got eaten
            if (this.name == "star")
            {
                Debug.Log("collided");
                lv_control.GetInstance.got_star();
                this.gameObject.SetActive(false);
            }
            if (this.name == "gate") {
                lv_control.GetInstance.win();
            }
            if (this.tag == "monster") {
                lv_control.GetInstance.dead();
            }
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
