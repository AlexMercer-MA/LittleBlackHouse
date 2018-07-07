using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePropertyManager : MonoBehaviour
{

    public GameObject line;//这个是线

    public static GamePropertyManager GetInstance;
    public bool World_is_A = false;
    public int ignoreLayerIndex;
    public float gravityAbs = 9.8f;
    public float moveSpeed = 10.0f;
    public GameObject world_player_a;
    public GameObject world_player_b;
    public mycharacter_controller controller_a;
    public mycharacter_controller controller_b;

    void Awake()
    {
        GetInstance = this;
        ignoreLayerIndex = 9;// LayerMask.GetMask("Player", "IgnoreCollision");

    }

    void FixedUpdate()
    {
        //if (Input.GetInstanceKeyUp(KeyCode.K)){
        //    LV1_switch();
        //}
        //跟随
        if (LineControl.Get_obj.Object_In_A_World(world_player_a.transform.localPosition))
        {
            world_player_b.transform.localPosition = world_player_a.transform.localPosition;
        }
        else
        {
            world_player_a.transform.localPosition = world_player_b.transform.localPosition;
        }
    }



    public void World_switch()
    {
        // 当前是A，切换之后为B
        if (World_is_A)
        {
            world_player_b.transform.GetComponent<CapsuleCollider2D>().isTrigger = false;
            world_player_a.transform.GetComponent<CapsuleCollider2D>().isTrigger = true;

            world_player_b.GetComponent<mycharacter_controller>().change_gravity();
            World_is_A = false;
        }
        else
        {
            world_player_b.transform.GetComponent<CapsuleCollider2D>().isTrigger = true;
            world_player_a.transform.GetComponent<CapsuleCollider2D>().isTrigger = false;

            world_player_a.GetComponent<mycharacter_controller>().change_gravity();
            World_is_A = true;
        }
    }
}
