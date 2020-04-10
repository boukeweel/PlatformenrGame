using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public enum PlayerStatus
{
    Idel,
    Walking,
    Running,
    Jumping,
    Landing,
    
}



public class Player : MonoBehaviour
{
    [Header("Jumping Varibelen")]
    //everything for jumping
    public float MaxJumping = 2;
    public float jumps = 0;
    public float Jumpingforce = 2f;
    public bool grounded = true;
    
    


    Rigidbody2D rig2d;
    [Header("witch Xbox Controller is this Player for")]
    public XboxController PlayerNumber = XboxController.Any;

    public float speed;
    float S_Speed;

    float Xaxis;
    float S_Xasis;

    Vector3 movement;
    public PlayerStatus playerStatus = PlayerStatus.Idel;

    SpriteRenderer srend;

    //for sliddig
    public float slidingspeed;
    public BoxCollider2D normaleCol;
    public BoxCollider2D SlidingCol;
    public bool sliding;

    public bool allowedTomove;


    Animator ani;

    bool Spriting = false;

    public bool lastjump;

    bool walking = false;
    float timer;
    float timefortimer = 0.4f;

    bool jumping = false;
    private void Start()
    {
        rig2d = GetComponent<Rigidbody2D>();
        S_Speed = speed;
        srend = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    
    }

    private void FixedUpdate()
    {
        Xaxis = XCI.GetAxis(XboxAxis.LeftStickX, PlayerNumber);
        //Yaxis = XCI.GetAxis(XboxAxis.LeftStickY, PlayerNumber);

        //sprinting
        if (XCI.GetButtonDown(XboxButton.LeftBumper, PlayerNumber))
        {
            speed = 12f;
            Spriting = true;
            timefortimer = 0.2f;
        }
        if (XCI.GetButtonUp(XboxButton.LeftBumper, PlayerNumber))
        {
            speed = 6f;
            Spriting = false;
            timefortimer = 0.4f;
        }

        //movement
        transform.Translate(new Vector3(Xaxis * Time.deltaTime * speed, 0f, 0f));
        if (Xaxis > 0.1f)
        {
            srend.flipX = false;
            walking = true;
        }
        if(Xaxis < -0.1f)
        {
            srend.flipX = true;
            walking = true;
        }
        if(Xaxis == 0)
        {
            walking = false;
        }
        if(walking == true && grounded == true)
        {
            timer += Time.deltaTime;
            if(timer >= timefortimer)
            {
                FindObjectOfType<audiomanger>().play("Walking");
                timer = 0;
            }
            
        }



        if (XCI.GetButtonDown(XboxButton.A, PlayerNumber) && grounded == false)
        {
            if (grounded == false)
            {
                if (lastjump == true)
                {
                    rig2d.velocity = Vector2.up * 10;
                    jumps = jumps + 1;
                    FindObjectOfType<audiomanger>().play("jump");
                    lastjump = false;
                    jumping = true;
                }
                

            }
        }

        // jump
        if (XCI.GetButtonDown(XboxButton.A, PlayerNumber) == true)
        {
            if (grounded == true)
            {
                rig2d.velocity = Vector2.up * Jumpingforce;
                S_Xasis = Xaxis;
                S_Speed = speed;
                jumps = 1;
                jumping = true;
                FindObjectOfType<audiomanger>().play("jump");

                grounded = false;

            }
        }

        

        //if (XCI.GetButtonDown(XboxButton.B,PlayerNumber) && grounded == true)
        //{
        //    Slidding();
        //}
        if (srend.flipX == false && sliding == true)
        {
            rig2d.AddForce(Vector2.right * slidingspeed);
        }
        if (srend.flipX == true && sliding == true )
        {
            rig2d.AddForce(Vector2.left * slidingspeed);
        }

        WelkeState();

    }

    private void WelkeState()
    {
        if (jumping == true)
        {
            playerStatus = PlayerStatus.Jumping;
        }
        if (Xaxis == 0.0f)
        {
            playerStatus = PlayerStatus.Idel;
        }
        else if (Spriting == true)
        {
            playerStatus = PlayerStatus.Running;
        }
        else 
        {
            playerStatus = PlayerStatus.Walking;
        }
        
        
        
        ChangeAnimation();
    }
    
    //change de animation
    private void ChangeAnimation()
    {
        if(playerStatus == PlayerStatus.Idel)
        {
            ani.SetInteger("Welke", 0);
        }
        if(playerStatus == PlayerStatus.Walking)
        {
            ani.SetInteger("Welke", 1);
        }
        if(playerStatus == PlayerStatus.Running)
        {
            ani.SetInteger("Welke", 2);
        }
        if (playerStatus == PlayerStatus.Jumping)
        {
            ani.SetInteger("Welke", 3);
        }
        
        
    }
    
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Doos"))
        {
            grounded = true;
            FindObjectOfType<audiomanger>().play("Land");
            lastjump = false;
            jumps = 0;
            jumping = false;
            //playerStatus = PlayerStatus.Idel;

            //ChangeAnimation();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Doos"))
        {
            grounded = false;
            lastjump = true;
            if (jumps < 1)
            {
                jumps  = 1;
            }
        }
    }
    
      




}
