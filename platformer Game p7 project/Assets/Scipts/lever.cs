using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class lever : MonoBehaviour
{
    
     Player p;
    private GameManger gm;

    private void Start()
    {
        gm = GetComponentInParent<GameManger>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            //Debug.Log("ja");
            p = other.gameObject.GetComponent<Player>();
            if (XCI.GetButtonDown(XboxButton.X, p.PlayerNumber))
            {
                //Debug.Log("kilk");
                gm.OpDoor();
            }
        }
    }
}
