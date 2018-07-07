using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenGameStart : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject);	
	}
	
}
