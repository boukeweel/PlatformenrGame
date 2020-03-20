using System.Collections;
using System.Collections.Generic;
using XboxCtrlrInput;
using UnityEngine;

public class Doos : MonoBehaviour
{
    private Player p;
    private void Start()
    {
        p.GetComponent<Player>();
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Doos"))
        {
            if (XCI.GetButtonDown(XboxButton.A, p.PlayerNumber))
            {
                
            }
        }
    }
}
