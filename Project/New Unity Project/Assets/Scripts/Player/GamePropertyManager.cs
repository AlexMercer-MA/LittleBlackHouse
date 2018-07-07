using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePropertyManager : MonoBehaviour
{

    public GameObject line;//这个是线

    public static GamePropertyManager GetInstance;
    public bool World_is_A = false;
    public float jumpSpeed = 10.0f;
    //public int ignoreLayerIndex;
    public float gravityAbs = 9.8f;
    public float moveSpeed = 10.0f;

    public GameObject Character_A;
    public GameObject Character_B;

    public int colliderLayer_world_A;
    public int colliderLayer_world_B;

    void Awake()
    {
        GetInstance = this;
        //ignoreLayerIndex = 9;// LayerMask.GetMask("Player", "IgnoreCollision");
        Character_A = GameObject.Find("Character_A");
        Character_B = GameObject.Find("Character_B");

        //colliderCheck.cs 中碰撞题所在层级判断
        colliderLayer_world_A = GameObject.Find("WorldA").layer;
        colliderLayer_world_B = GameObject.Find("WorldB").layer;
    }
}
