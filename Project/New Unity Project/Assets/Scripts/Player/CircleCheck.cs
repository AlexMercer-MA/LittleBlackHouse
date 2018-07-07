using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CircleCheck : MonoBehaviour {

    public int collisionTargerNum = 0;
    public CircleCollider2D circleCollider; 
    
	void Awake ()
    {
        circleCollider = this.GetComponent<CircleCollider2D>();
	}
    
    void OnTriggerEnter2D(Collider2D collider)
    {

        Debug.Log(collider.name+" in");
//        if (collider.gameObject.layer != GamePropertyManager.GetInstance.ignoreLayerIndex )
  //      {
            collisionTargerNum++;
    //    }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log(collider.name+" out");
        //  if (collider.gameObject.layer != GamePropertyManager.GetInstance.ignoreLayerIndex)
        //{
        collisionTargerNum--;
        //}
    }

    public bool CheckCollided()
    {
        return(collisionTargerNum > 0) ? true : false;
    }
}
