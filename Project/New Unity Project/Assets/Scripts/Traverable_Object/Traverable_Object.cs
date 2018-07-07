using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class Traverable_Object : MonoBehaviour
{
    [Tooltip("A世界物体")]
    public Transform World_A_Transform;
    [Tooltip("B世界物体")]
    public Transform World_B_Transform;

    Rigidbody2D rigi_A;
    Rigidbody2D rigi_B;

    Collider2D collider_A;
    Collider2D collider_B;

    [Tooltip("是否在A世界")]
    [SerializeField]
    protected bool Is_In_A_World;

    [SerializeField]
    protected bool Is_Can_Pass_World=true;

    

    [Tooltip("改变主世界，仅用于测试")]
    protected bool Change_Main_World=false;

    public virtual void Start()
    {
        rigi_A = World_A_Transform.GetComponent<Rigidbody2D>();
        rigi_B = World_B_Transform.GetComponent<Rigidbody2D>();

        collider_A = World_A_Transform.GetComponent<Collider2D>();
        collider_B = World_B_Transform.GetComponent<Collider2D>();
        StartDealPosition();
        Update_Object_Trigger();

    }
    ///去A世界 
    public virtual void Go_A_World()
    {
     
        collider_A.isTrigger = false;
        collider_B.isTrigger = true;
        Is_In_A_World = true;
    }
    ///去B世界 
    public virtual void Go_B_World()
    {
     
        collider_A.isTrigger = true;
        collider_B.isTrigger = false;
        Is_In_A_World = false;
    }

    /// <summary>
    ///  更新是否是碰撞体或者触发器
    /// </summary>
    protected void Update_Object_Trigger()
    {
        //Debug.Log("在A世界吗" + LineControl.Get_obj.Object_In_A_World(World_A_Transform.localPosition));
        if (LineControl.Get_obj.Object_In_A_World(World_A_Transform.localPosition))
        {
            if(Is_In_A_World==false)
            {
                Go_A_World();
            }

        }
        else
        {
            if (Is_In_A_World == true)
            {
                Go_B_World();
            }
           
        }
    }

    /// <summary>
    /// 初始化同步两个世界的物体坐标
    /// </summary>
    protected void StartDealPosition()
    {
        if (Change_Main_World)
        {
            World_B_Transform.localPosition = World_A_Transform.localPosition;
        }
        else
        {
            World_A_Transform.localPosition = World_B_Transform.localPosition;
        }
    }

    protected void Update()
    {
        if(Is_Can_Pass_World)
        {
            Update_Object_Trigger();
        }
        else
        {
            //物体在A世界，但物体坐标已经在B世界的情况需要切换世界
            if (Is_In_A_World&& LineControl.Get_obj.Object_In_B_World(World_A_Transform.localPosition))
            {
                rigi_A.AddForce(GameManerge.Get_obj.LineForece,ForceMode2D.Force);

            }
            else if(!Is_In_A_World && LineControl.Get_obj.Object_In_A_World(World_A_Transform.localPosition))
            { //物体在B世界，但物体坐标已经在A世界的情况需要切换世界
                rigi_B.AddForce(GameManerge.Get_obj.LineForece, ForceMode2D.Force);

            }
        }
        if(Is_In_A_World)
        {
            World_B_Transform.localPosition = World_A_Transform.localPosition;
        }
        else
        {
            World_A_Transform.localPosition = World_B_Transform.localPosition;
        }
    }
}

