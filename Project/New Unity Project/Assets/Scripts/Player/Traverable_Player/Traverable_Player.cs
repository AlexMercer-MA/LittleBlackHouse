﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 仅控制游戏玩家的，穿越世界的脚本
/// </summary>
public class Traverable_Player:Traverable_Object
{
    protected mycharacter_controller player_a;
    protected mycharacter_controller player_b;

    public override void Start()
    {
        base.Start();
        player_a = World_A_Transform.GetComponent<mycharacter_controller>();

        player_b = World_B_Transform.GetComponent<mycharacter_controller>();
    }

    public override void Go_A_World()
    {
        base.Go_A_World();
        player_a.speedX = player_b.speedX;
        World_A_Transform.localPosition = World_B_Transform.localPosition;
        player_a.speedY = player_b.speedY;
     /*   player_a.enabled = true;
        player_b.enabled = false;*/
    }
    public override void Go_B_World()
    {
        base.Go_B_World();
        player_b.speedX = player_a.speedX;
        player_b.speedY = player_a.speedY;
        World_B_Transform.localPosition = World_A_Transform.localPosition;
        /*player_b.enabled = true;
        player_a.enabled = false;*/
    }
}

