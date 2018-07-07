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
    private bool Is_In_A_World;

    private bool Is_Can_Pass_World;

    [Tooltip("改变主世界，仅用于测试")]
    public bool Change_Main_World=false;

    private void Start()
    {
        rigi_A = World_A_Transform.GetComponent<Rigidbody2D>();
        rigi_B = World_B_Transform.GetComponent<Rigidbody2D>();

        collider_A = World_A_Transform.GetComponent<Collider2D>();
        collider_B = World_B_Transform.GetComponent<Collider2D>();
        StartDealPosition();
        Update_Object_Trigger();

    }
    /// <summary>
    ///  更新是否是碰撞体或者触发器
    /// </summary>
    private void Update_Object_Trigger()
    {
        if (LineControl.Get_obj.Object_In_A_World(World_A_Transform.localPosition))
        {
            collider_A.isTrigger = false;
            collider_B.isTrigger = true;
            Is_In_A_World = true;
        }
        else
        {
            collider_A.isTrigger = true;
            collider_B.isTrigger = false;
            Is_In_A_World = false;
        }
    }

    /// <summary>
    /// 初始化同步两个世界的物体坐标
    /// </summary>
    private void StartDealPosition()
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

    private void Update()
    {
        if(Is_Can_Pass_World)
        {
            Update_Object_Trigger();
        }
        else
        {
            //物体在A世界，但物体坐标已经在B世界的情况
            if (Is_In_A_World&& LineControl.Get_obj.Object_In_B_World(World_A_Transform.localPosition))
            {
                rigi_A.AddForce(GameManerge.Get_obj.LineForece,ForceMode2D.Force);
            }
            else if(!Is_In_A_World && LineControl.Get_obj.Object_In_A_World(World_A_Transform.localPosition))
            { //物体在B世界，但物体坐标已经在A世界的情况
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

