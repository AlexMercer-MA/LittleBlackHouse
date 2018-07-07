using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderCheck : MonoBehaviour {

    public GameObject player_A;
    public GameObject player_B;


    public bool isWorld_A;
    bool self_isWorld_A;

    // Use this for initialization
    void Start()
    {
        if (this.gameObject.layer == 8)
        {
            self_isWorld_A = true;
        }
        else if (this.gameObject.layer == 9)
        {
            self_isWorld_A = false;
        }
    }

    void OnTriggerEnter2D(Collider2D tempCollider)
    {
        isWorld_A = LineControl.Get_obj.Object_In_A_World(player_A.transform.localPosition) ? true : false ;
        if (isWorld_A != self_isWorld_A)
        {
            return;
        }
        if (tempCollider.tag == "Player") {
            //got eaten
            if (this.name == "star")
            {
                if (tempCollider.isActiveAndEnabled)
                {
                    lv_control.GetInstance.got_star();
                    this.gameObject.SetActive(false);
                }
            }
            if (this.name == "gate") {
                lv_control.GetInstance.win();
            }
            if (this.tag == "monster") {
                lv_control.GetInstance.dead();

                Destroy(player_A);
                Destroy(player_B);
            }
        }
    }
	
}
