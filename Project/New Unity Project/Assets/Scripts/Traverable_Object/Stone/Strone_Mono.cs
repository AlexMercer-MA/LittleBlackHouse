using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Strone_Mono:Traverable_Object
{

    public bool Is_Move = false;
    private Vector3 position_ed;
    public float Min_Move_V = 0.1f;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if ((World_A_Transform.localPosition - position_ed).magnitude<= Min_Move_V)
        {
            Is_Move = false;
        }
        else
        {
            Is_Move = true;
        }
        position_ed = World_A_Transform.localPosition;

        
    }

    public override void Go_A_World()
    {
        base.Go_A_World();
    }

    public override void Go_B_World()
    {
        base.Go_B_World();
    }

    protected override void ZhuangQiangA()
    {
        
    }

    protected override void ZhuangQiangB()
    {
       
    }
}

