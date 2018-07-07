using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoxCollider : MonoBehaviour {
    
	void OnEnable () 
    {
        this.gameObject.AddComponent<BoxCollider2D>();
	}
	
}
