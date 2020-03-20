using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PGrab : MonoBehaviour
{
    public Player p;
    private void Start()
    {
        p = GetComponent<Player>();
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Doos"))
        {
            if (XCI.GetButtonDown(XboxButton.X, p.PlayerNumber))
            {
                collision.collider.transform.parent = transform;
            }
        }
    }
}
