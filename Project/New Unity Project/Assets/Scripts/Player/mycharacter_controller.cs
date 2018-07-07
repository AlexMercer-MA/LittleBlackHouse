using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class mycharacter_controller : MonoBehaviour
{
    public GameObject friend;
    public float gravity = 9.8f;
    public static CharacterController GetInstance;
    Rigidbody2D rb2d;
    Animator anim;
    public CircleCheck groundCheck;
    public CircleCheck ceilCheck;

    public bool isGrounded;
    public bool isCeiled;
    public float initialYSpeed = -1.0f;
    public float moveSpeed = 10.0f;
    public float jumpSpeed = 10.0f;
    public float speedX;
    public float speedY;
    bool bFaceRight_Current = true;
    bool bFaceRight_Previous = true;
    int hSpeedID;
    int vSpeedID;
    int bGround;
    int bCrouch;
    private void Awake()
    {
//        GetInstance = this.GetComponent<CharacterController>();
        rb2d = this.transform.GetComponent<Rigidbody2D>();
        anim = this.transform.GetComponent<Animator>();
    }
    /*
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name == "line")
        {
            GamePropertyManager.GetInstance.LV1_switch();
        }
    }*/

    public void change_gravity()
    {
        if (isGrounded || speedY<1) { speedY = 0; } else { speedY *= -1; }
       
            friend.GetComponent<mycharacter_controller>().speedY = speedY;
       
    }

    private void Start()
    {
        hSpeedID = Animator.StringToHash("hSpeed");
        vSpeedID = Animator.StringToHash("vSpeed");
    }


    void FixedUpdate()
    {
        isGrounded = groundCheck.CheckCollided();

        isCeiled = ceilCheck.CheckCollided();

        //Change Horizontal Speed
        speedX = PlayerInput.GetInstance.inputX * moveSpeed;
        //Change Vertical Speed
        if (!isGrounded)
        {
            speedY = speedY - gravity * Time.fixedDeltaTime;
        }
        else
        {
            speedY = 0;
            //            friend.GetComponent<CharacterController>().speedY = 0;
        }
        //Check Jump
        if (PlayerInput.GetInstance.jump && isGrounded)
        {
            speedY += jumpSpeed * (gravity / 9.8f) * 0.4f;
        }

        rb2d.velocity = new Vector2(speedX, speedY);
    }

    void Update()
    {
        if (speedX > 0)
        {
            bFaceRight_Current = true;
        }
        else if (speedX < 0)
        {
            bFaceRight_Current = false;
        }
        if (bFaceRight_Current != bFaceRight_Previous)
        {
            Vector3 newlocalScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
            this.transform.localScale = newlocalScale;
        }

        anim.SetFloat(hSpeedID, Mathf.Abs(speedX));
        if (isGrounded)
        {
            anim.SetFloat(vSpeedID, 0.0f);
        }
        else
        {
            anim.SetFloat(vSpeedID, speedY);
        }
        anim.SetBool("bGround", isGrounded);

        bFaceRight_Previous = bFaceRight_Current;
        /*
        if (LineControl.Get_obj.Object_In_A_World())
        {
            GamePropertyManager.GetInstance.LV1_switch();
        }*/
    }
}
