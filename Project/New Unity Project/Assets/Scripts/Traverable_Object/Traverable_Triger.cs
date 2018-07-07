using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Traverable_Triger:MonoBehaviour
{

    Traverable_Object TObject;
    private CD_box wait_check;

    bool Have_Object = false;
    public void Init(Traverable_Object TObject)
    {
        this.TObject = TObject;
        wait_check = new CD_box(0.05f);
    }

    public void Update()
    {
        //TObject.Is_Can_Pass_World = true;
        TObject.Is_Can_Pass_World = true;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag=="DiXing")
        {
            TObject.Is_Can_Pass_World = false;
        }
    }
}

