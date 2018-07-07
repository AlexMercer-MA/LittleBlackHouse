using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePropertyManager : MonoBehaviour
{

    public GameObject line;//这个是线

    public static GamePropertyManager GetInstance;
    public bool World_is_A = false;
    public float jumpSpeed = 10.0f;
    public int ignoreLayerIndex;
    public float gravityAbs = 9.8f;
    public float moveSpeed = 10.0f;

    void Awake()
    {
        GetInstance = this;
        ignoreLayerIndex = 9;// LayerMask.GetMask("Player", "IgnoreCollision");

    }

    void FixedUpdate()
    {
    
    }



  
}
