using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CircleCheck : MonoBehaviour {

    public int collisionTargerNum = 0;
    CircleCollider2D circleCollider;
    public string ignoreTagName = "ignore";
  
    void Awake ()
    {
        circleCollider = this.GetComponent<CircleCollider2D>();
     

    }
    /*
    void OnTriggerEnter2D(Collider2D tempCollider)
    {
        if (tempCollider.gameObject.tag != ignoreTagName)
        {
            collisionTargerNum++;
        }
    }

    void OnTriggerExit2D(Collider2D tempCollider)
    {
        if (tempCollider.gameObject.tag != ignoreTagName)
        {
            collisionTargerNum--;
        }
    }
    */
    public bool CheckCollided()
    {
        return ( circleCollider.OverlapCollider(GameManerge.Get_obj.canshu,new Collider2D[5])-1> 0) ? true : false;
    }
}
