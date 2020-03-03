﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public enum PlayerStatus
{
    Idel,
    Walking,
    Running,
    Jumping,
    Sliding,
    
}



public class Player : MonoBehaviour
{
    [Header("Jumping Varibelen")]
    //everything for jumping
    public float MaxJumping = 2;
    public float jumps = 0;
    public float Jumpingforce = 2f;
    bool grounded = false;
    
    


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
        }
        if (XCI.GetButtonUp(XboxButton.LeftBumper, PlayerNumber))
        {
            speed = 6f;
            Spriting = false;
        }

        //movement
        transform.Translate(new Vector3(Xaxis * Time.deltaTime * speed, 0f, 0f));
        if (Xaxis > 0.1f)
        {
            srend.flipX = false;
            
        }
        if(Xaxis < -0.1f)
        {
            srend.flipX = true;
        }
        
        
        

        
        // jump
        if(XCI.GetButtonDown(XboxButton.A, PlayerNumber))
        {
           
            
            if(grounded == true)
            {
                rig2d.velocity = Vector2.up * Jumpingforce;
                S_Xasis = Xaxis;
                S_Speed = speed;
                
                grounded = false;
            }
            if (grounded == false)
            {
                if (jumps == 1)
                {
                    rig2d.velocity = Vector2.up * 10;
                    jumps++;

                }

            }



        }
        if (XCI.GetButtonUp(XboxButton.A, PlayerNumber))
        {
            jumps++;
        }

        if(XCI.GetButtonDown(XboxButton.B,PlayerNumber) && grounded == true)
        {
            Slidding();
        }
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
        if (grounded == false)
        {
            playerStatus = PlayerStatus.Jumping;
        }
        if (sliding == true)
        {
            playerStatus = PlayerStatus.Sliding;
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

        }
        if(playerStatus == PlayerStatus.Sliding)
        {

        }
    }
    public void Slidding()
    {
        sliding = true;

        SlidingCol.enabled = true;
        normaleCol.enabled = false;
        


        StartCoroutine("stopSliding");

    }
    IEnumerator stopSliding()
    {
        yield return new WaitForSeconds(0.8f);
        sliding = false;
        normaleCol.enabled = true;
        SlidingCol.enabled = false;


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = true;
            
            jumps = 0;
        }
        

    }
    

    public void Powerup(float ADDJumpingHeigth,float ADDspeed)
    {
        
    }


}
