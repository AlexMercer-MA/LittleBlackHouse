using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public static PlayerInput GetInstance;

    //Ctrl R + E        自动补全属性 Ctrl R+E
    //prop + Tab + Tab  自动生成属性 输入prop 双击Tab
    float input_x;
    float input_y;
    bool input_jump;

    public float inputX { get{ return input_x; } set { input_x = value; } }
    public float inputY { get { return input_y; } set { input_y = value; } }
    public bool jump { get { return input_jump; } set { input_jump = value; } }

    private void Awake()
    {
        GetInstance = this;    
    }

	void Update ()
    {
        input_x = Input.GetAxis("Horizontal");
        input_y = Input.GetAxis("Vertical");
        input_jump = Input.GetButtonDown("Jump") ? true : false;
        
        /*
        Debug.Log(inputX);
        Debug.Log(inputY);
        Debug.Log(jump);
        */
    }
}
