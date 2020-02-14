using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public enum Jumpingstate
{
    Grounded,
    Preparing,
    Jumping,
    Landing,
}



public class Player : MonoBehaviour
{
    [Header("Jumping Varibelen")]
    //everything for jumping
    public float MaxJumping = 2;
    float jumps = 0;
    public float Jumpingforce = 2f;
    bool grounded = false;
    public float MaxJumpingHeigt;
    float S_Jumpingforce;


    Rigidbody2D rig2d;
    [Header("witch Xbox Controller is this Player for")]
    public XboxController PlayerNumber = XboxController.Any;

    public float speed;
    float S_Speed;

    float Xaxis;
    float S_Xasis;

    Vector3 movement;
    //public Jumpingstate M_jumpingstate = Jumpingstate.Grounded;

    SpriteRenderer srend;

    //for sliddig
    public float slidingspeed;
    public BoxCollider2D normaleCol;
    public BoxCollider2D SlidingCol;
    public bool sliding;

    public bool allowedTomove;


    private void Start()
    {
        rig2d = GetComponent<Rigidbody2D>();
        S_Speed = speed;
        S_Jumpingforce = Jumpingforce;
        srend = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Xaxis = XCI.GetAxis(XboxAxis.LeftStickX, PlayerNumber);
        //Yaxis = XCI.GetAxis(XboxAxis.LeftStickY, PlayerNumber);

        //sprinting
        if (XCI.GetButtonDown(XboxButton.LeftBumper, PlayerNumber))
        {
            speed *= 1.5f;
        }
        if (XCI.GetButtonUp(XboxButton.LeftBumper, PlayerNumber))
        {
            speed /= 1.5f;
        }

        //movement
        if(grounded == true)
        {
            transform.Translate(new Vector3(Xaxis * Time.deltaTime * speed, 0f, 0f));
        }
        else
        {
            //On Jumping not ably to move
            transform.Translate(new Vector3(S_Xasis * Time.deltaTime * S_Speed, 0f, 0f));
        }
        if(Xaxis > 0.1f)
        {
            srend.flipX = false;
        }
        if(Xaxis < -0.1f)
        {
            srend.flipX = true;
        }
            
        
        
        //jump heiger if you hold 
        if (XCI.GetButton(XboxButton.A, PlayerNumber) && grounded == true)
        {
            Jumpingforce += 0.1f;
            if(Jumpingforce > MaxJumpingHeigt)
            {
                Jumpingforce = MaxJumpingHeigt + 1;
            }
        }
        //jump
        if (XCI.GetButtonUp(XboxButton.A, PlayerNumber) && grounded == true)
        {
            S_Xasis = Xaxis;
            S_Speed = speed;
            rig2d.velocity = Vector2.up * Jumpingforce;
            Jumpingforce = S_Jumpingforce;
            jumps++;
            grounded = false;
        }
        //double jump
        if(XCI.GetButtonDown(XboxButton.A, PlayerNumber) && jumps < MaxJumping && grounded == false)
        {
            rig2d.velocity = Vector2.up * 10;
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

    }
    public void Slidding()
    {
        sliding = true;

        //normaleCol.enabled = false;
        //SlidingCol.enabled = true;

        
        StartCoroutine("stopSliding");

    }
    IEnumerator stopSliding()
    {
        yield return new WaitForSeconds(0.8f);
        sliding = false;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = true;
            jumps = 0;
        }
    }


}
