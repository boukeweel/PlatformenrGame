using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DePowerup : MonoBehaviour
{
    public PowerUps powerup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            Player p = other.gameObject.GetComponent<Player>();
            p.Powerup(powerup.ADDjumpingHeigth, powerup.ADDspeed);
        }
    }
}
