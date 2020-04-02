using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class doos : MonoBehaviour
{
    //[SerializeField] private XboxController m_controller;
    private bool hold = false;
    public Player p;
   
    private void OnCollisionStay2D(Collision2D col)
    {

            if(col.gameObject.tag == "Player" && XCI.GetButtonDown(XboxButton.X   ,p.PlayerNumber) && !hold)
            {
                
                this.transform.parent = col.transform;
                hold = true;
            }
            if (col.gameObject.tag == "Player" && XCI.GetButtonUp(XboxButton.X, p.PlayerNumber) && hold)
            {
                this.transform.parent = null;
                hold = false;
            }
    }
    
}
