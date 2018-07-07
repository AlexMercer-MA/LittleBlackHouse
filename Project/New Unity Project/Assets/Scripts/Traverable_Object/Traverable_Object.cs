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

    protected Rigidbody2D rigi_A;
    protected Rigidbody2D rigi_B;

    protected Collider2D collider_A;
    protected Collider2D collider_B;

    [Tooltip("是否在A世界")]
    [SerializeField]
    public bool Is_In_A_World;

    [SerializeField]
    public bool Is_Can_Pass_World=true;

    private bool Add_ForcA = false;
    private bool Add_ForcB = false;


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
      //  World_A_Transform.gameObject.AddComponent<Traverable_Triger>().Init(this);
      //  World_B_Transform.gameObject.AddComponent<Traverable_Triger>().Init(this);
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

    protected virtual void Deal_Triger()
    {

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


    protected virtual void FixedUpdate()
    {
        if(Add_ForcA)
        {
            ZhuangQiangA();
        }
        if (Add_ForcB)
        {
            ZhuangQiangB();
        }
    }

    protected virtual void ZhuangQiangA()
    {
        if (Mathf.Abs(rigi_A.velocity.x - (-LineControl.Get_obj.Line_Vecter)) < 0.1)
        {
            Vector3 temple = World_A_Transform.localPosition;
            temple.x = LineControl.Get_obj.Line_Position;
            World_A_Transform.localPosition = temple;
        }
        else if (rigi_A.velocity.x > 0)
        {
            Vector3 temple = rigi_A.velocity;
            temple.x *=-1;
            rigi_A.velocity = temple;
        }
    }

    protected virtual void ZhuangQiangB()
    {
        if (Mathf.Abs(rigi_B.velocity.x - (-LineControl.Get_obj.Line_Vecter)) < 0.1)
        {
            Vector3 temple = World_B_Transform.localPosition;
            temple.x = LineControl.Get_obj.Line_Position;
            World_B_Transform.localPosition = temple;
        }
        else if (rigi_A.velocity.x > 0)
        {
            Vector3 temple = rigi_B.velocity;
            temple.x *= -1;
            rigi_B.velocity = temple;
        }
    }

    protected virtual void Update()
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
                Add_ForcA = true;
                Add_ForcB = false;
            }
            else if(!Is_In_A_World && LineControl.Get_obj.Object_In_A_World(World_A_Transform.localPosition))
            { //物体在B世界，但物体坐标已经在A世界的情况需要切换世界
                Add_ForcB = true;
                Add_ForcA = false;
            }
            else
            {
                Add_ForcA = false;
                Add_ForcB = false;
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

