using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGrab : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.GetComponent<Player>())
        {
            Player p = collision.collider.GetComponent<Player>();
            
        }
    }
}
