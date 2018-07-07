using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.transform.position = new Vector3(this.transform.position.x + 5f, this.transform.position.y, this.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
