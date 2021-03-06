﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderCheck : MonoBehaviour {

    public GameObject character_A;
    public GameObject character_B;

    public bool isWorld_A;
    public bool self_isWorld_A;

    private void Awake()
    {
        this.gameObject.layer = this.transform.parent.gameObject.layer;
    }

    //根据父级物体，自动设置层级
    void Start()
    {
        if (this.gameObject.layer == GamePropertyManager.GetInstance.colliderLayer_world_A)
        {
            self_isWorld_A = true;
        }
        else if(this.gameObject.layer == GamePropertyManager.GetInstance.colliderLayer_world_B)
        {
            self_isWorld_A = false;
        }

        character_A = GamePropertyManager.GetInstance.Character_A;
        character_B = GamePropertyManager.GetInstance.Character_B;

        int parentLayerIndex = this.transform.parent.gameObject.layer;

        this.gameObject.layer = parentLayerIndex;
    }

    //进入触发器范围之后的逻辑处理
    void OnTriggerEnter2D(Collider2D tempCollider)
    {
        isWorld_A = LineControl.Get_obj.Object_In_A_World(character_A.transform.localPosition) ? true : false ;

        if (isWorld_A != self_isWorld_A)
        {
            return;
        }

        if (tempCollider.tag == "Player") 
        {
            //got eaten
            if (this.name == "star")
            {
                if (tempCollider.isActiveAndEnabled)
                {
                    lv_control.GetInstance.got_star();
                    this.gameObject.SetActive(false);
                }
            }
            if (this.name == "gate") 
            {
                lv_control.GetInstance.win();
            }
            if (this.tag == "monster") 
            {
                lv_control.GetInstance.dead();

                Destroy(character_A);
                Destroy(character_B);
            }
        }
    }
}
