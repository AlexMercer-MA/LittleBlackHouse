using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Traverable_Triger:MonoBehaviour
{

    Traverable_Object TObject;
    private CD_box wait_check;
    private BoxCollider2D Colloder;
    bool Have_Object = false;
    private Collider2D[] collider2Ds;

    public void Start()
    {
        Colloder = GetComponent<BoxCollider2D>();
        Init();
    }

    public void Init()
    {
        this.TObject = Traverable_Player.GetInstance;
        wait_check = new CD_box(0.05f);
        collider2Ds = new Collider2D[20];
    }

    public void Update()
    {
        ///Debug.Log(CheckCollided()) ;
        
        if(TObject.Is_In_A_World&& transform.parent.name== "Character_B")
        {
            TObject.Is_Can_Pass_World = CheckCollided() == 0;
        }
        else if(!TObject.Is_In_A_World && transform.parent.name == "Character_A")
        {
            TObject.Is_Can_Pass_World = CheckCollided() == 0;
        }
     
    }
    public int CheckCollided()
    {
        int di_number = 0;
        int number = Colloder.OverlapCollider(GameManerge.Get_obj.canshu, collider2Ds);
        for (int i = 0; i < number; i++)
        {
            if (collider2Ds[i].tag == "DiXing")
            {
                di_number++;
              
            }
        }
        return di_number;

    }

}

