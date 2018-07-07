using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class mycharacter_controller : MonoBehaviour
{
    public GameObject friend;
    public static CharacterController GetInstance;
    Rigidbody2D rb2d;
    Animator anim;
    public CircleCheck groundCheck;
    public CircleCheck ceilCheck;
    public int gMultiplier;
    public bool isZhuangQiang;
    public bool isGrounded;
    public bool isCeiled;
    public float initialYSpeed = -1.0f;
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
        rb2d = this.transform.GetComponent<Rigidbody2D>();
        anim = this.transform.GetComponent<Animator>();
    }

    
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
        speedX = PlayerInput.GetInstance.inputX * GamePropertyManager.GetInstance.moveSpeed;
        anim.SetBool("IsMove", speedX != 0);


        //Change Vertical Speed
        if (!isGrounded)
        {
            speedY = speedY + (gMultiplier * GamePropertyManager.GetInstance.gravityAbs) * Time.fixedDeltaTime;
        }
        //Check Jump
        else if (PlayerInput.GetInstance.jump && isGrounded)
        {
            Vector2 temple = rb2d.position;
            temple.y-=gMultiplier * 0.01f;
            rb2d.position = temple;
            speedY += GamePropertyManager.GetInstance.jumpSpeed * (-gMultiplier *  GamePropertyManager.GetInstance.gravityAbs );
            anim.SetTrigger("Jump");
            SoundManerge.Get_obj.PlayAudio(0);
        }
        else
        {
            speedY = 0;
        }

       

        rb2d.velocity = new Vector2(speedX, speedY);
    }

    public void Die()
    {

        anim.SetTrigger("Die");
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



#region
/*
void OnTriggerExit2D(Collider2D collider)
{
    if (collider.name == "line")
    {
        GamePropertyManager.GetInstance.LV1_switch();
    }
}*/
#endregion
