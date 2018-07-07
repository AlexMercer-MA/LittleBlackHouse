using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePropertyManager : MonoBehaviour {
    public GameObject line;//这个是线


    void line_cross_person() {//如果
        

    }

    public static GamePropertyManager GetInstance;
    public bool a_open = false;
    public int ignoreLayerIndex;
//    public float gravity = -9.8f;
    public GameObject world_1_player;
    public GameObject world_2_player;
    


    void Update() {
        if (Input.GetKeyUp(KeyCode.K)){
            LV1_switch();
        }
        //跟随
        if (LineControl.Get_obj.Object_In_A_World(world_1_player.transform.localPosition))
        {
            world_2_player.transform.localPosition = world_1_player.transform.localPosition;
        }
        else {
            world_1_player.transform.localPosition = world_2_player.transform.localPosition;
        }
    }
    


    void Awake ()
    {
        GetInstance = this;
        ignoreLayerIndex = 9;// LayerMask.GetMask("Player", "IgnoreCollision");
    }
    public void LV1_switch() {
        if (a_open) {
            a_open = false;
            world_2_player.transform.GetComponent<CapsuleCollider2D>().isTrigger = false;
            world_1_player.transform.GetComponent<CapsuleCollider2D>().isTrigger = true;

            world_2_player.GetComponent<mycharacter_controller>().change_gravity();
        }
        else {
            world_2_player.transform.GetComponent<CapsuleCollider2D>().isTrigger = true;
            world_1_player.transform.GetComponent<CapsuleCollider2D>().isTrigger = false;

            world_1_player.GetComponent<mycharacter_controller>().change_gravity();
            a_open = true;
        }
    }
    void LV2_switch() {
    }
    void LV3_switch() { }
}
