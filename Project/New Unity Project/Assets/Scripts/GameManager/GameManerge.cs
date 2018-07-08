using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameManerge:Single_Behaviour<GameManerge>
{
    [Tooltip("极限可到达坐标")]
    public Vector2 Max_Position;

    [Tooltip("线的排斥力")]
    public Vector2 LineForece;

    public ContactFilter2D canshu;

    private void Start()
    {

        GameObject Line_Prf = (GameObject)Resources.Load("LinePrf");
        Instantiate(Line_Prf);
    }
}

