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
    float jumps;
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

    private void Start()
    {
        rig2d = GetComponent<Rigidbody2D>();
        S_Speed = speed;
        S_Jumpingforce = Jumpingforce;
    }

    private void FixedUpdate()
    {
        Xaxis = XCI.GetAxis(XboxAxis.LeftStickX, PlayerNumber);
        //Yaxis = XCI.GetAxis(XboxAxis.LeftStickY, PlayerNumber);


        if (XCI.GetButtonDown(XboxButton.LeftBumper, PlayerNumber))
        {
            speed *= 1.5f;
        }
        if (XCI.GetButtonUp(XboxButton.LeftBumper, PlayerNumber))
        {
            speed /= 1.5f;
        }

        
        if(grounded == true)
        {
            transform.Translate(new Vector3(Xaxis * Time.deltaTime * speed, 0f, 0f));
        }
        else
        {
            //On Jumping not ably to move
            transform.Translate(new Vector3(S_Xasis * Time.deltaTime * S_Speed, 0f, 0f));
        }
            
        
        
        //jump heiger if you hold 
        if (XCI.GetButton(XboxButton.A, PlayerNumber))
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
            grounded = false;
        }
        


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = true;
        }
    }


}
