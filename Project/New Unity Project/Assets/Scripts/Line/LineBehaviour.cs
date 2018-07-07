using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBehaviour : MonoBehaviour {


    Collider2D collider;

    private void Awake()
    {
        collider = GetComponentInChildren<Collider2D>();
    }

    // Update is called once per frame
    void Update () {
        Vector3 Lp = transform.localPosition;
        Lp.x = (LineControl.Get_obj.Line_Number-0.5f)*2*GameManerge.Get_obj.Max_Position.x;
        transform.localPosition = Lp;
        if(Traverable_Player.GetInstance.Is_Can_Pass_World)
        {
            collider.isTrigger = true;
        }
        else
        {
            collider.isTrigger = false;
        }
    }
}
