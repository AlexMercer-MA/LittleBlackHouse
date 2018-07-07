using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoxCollider : MonoBehaviour {

    public bool isTrigger;

	void OnEnable () 
    {
        BoxCollider2D tempCollider = this.gameObject.AddComponent<BoxCollider2D>();

        if (isTrigger)
        {
            tempCollider.isTrigger = true;
        }

    }
	
}
