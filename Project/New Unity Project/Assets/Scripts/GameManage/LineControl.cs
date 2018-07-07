using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineControl : Single_Behaviour<LineControl> {
    [SerializeField]
    private float Line_number;
    public bool Is_test = false;
    public Material mat;
    [Tooltip("线循环时间")]
    public float Loop_Time=3;
    //获取线的数值
    public float Line_Number
    {
        get
        {
            return Line_number - (int)Line_number;
        }
    }

    /// <summary>
    /// 线左侧是A世界吗
    /// </summary>
    public bool Left_Is_A_World
    {
        get
        {
            return Line_number < 1;
        }
    }

    private CD_box Cd_Control;



	// Use this for initialization
	void Start () {
        //由A→B→A是两次
        Cd_Control = new CD_box(Loop_Time*2);
    }
	
	// Update is called once per frame
	void Update () {
        if(!Is_test)
        {
            update_deal_Line();
        }
     
        mat.SetFloat("_XianNumber", Line_number);
    }

    public void OnGUI()
    {
        GUIStyle temle = new GUIStyle();
        temle.fontSize = 50;
        GUILayout.Label(Line_Number.ToString(),temle);
    }

    /// <summary>
    /// 物体是否在A世界
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public bool Object_In_A_World(Vector2 position)
    {
       float obj_number =( position.x / GameManerge.Get_obj.Max_Position.x)*0.5f+0.5f;
        if(Left_Is_A_World)
        {
            return obj_number < Line_Number;
        }
        else
        {
            return obj_number > Line_Number;
        }
    }

    /// <summary>
    /// 物体是否在B世界
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public bool Object_In_B_World(Vector2 position)
    {
        return !Object_In_A_World( position);
    }

    /// <summary>
    /// 跟新线的位置
    /// </summary>
    private void update_deal_Line()
    {
        Line_number = 2 * Cd_Control.Countdown_ration;
        if(Cd_Control.IsOk)
        {
            Cd_Control.ReCd();
        }
    }
}
