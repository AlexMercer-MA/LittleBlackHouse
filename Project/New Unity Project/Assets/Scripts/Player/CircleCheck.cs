using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CircleCheck : MonoBehaviour {

    public int collisionTargerNum = 0;
    CircleCollider2D circleCollider;
    public string ignoreTagName = "ignore";
    Collider2D[] colliders;

    void Awake ()
    {
        circleCollider = this.GetComponent<CircleCollider2D>();
        colliders = new Collider2D[10];

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
        
        int number = circleCollider.OverlapCollider(GameManerge.Get_obj.canshu, colliders);
        for (int i = 0; i < number; i++)
        {
            if (colliders[i].tag == "DiXing")
                return true;
        }
        return false;
        //return ( circleCollider.OverlapCollider(GameManerge.Get_obj.canshu,new Collider2D[5])- collisionTargerNum > 0) ? true : false;
    }
}
