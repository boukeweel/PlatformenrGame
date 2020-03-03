using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DePowerup : MonoBehaviour
{
    public PowerUps powerup;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            Player p = other.gameObject.GetComponent<Player>();
            print("aangeraakt");
            p.Powerup(powerup.ADDjumpingHeigth, powerup.ADDspeed,powerup.timeforPowerup);
            Destroy(gameObject, 0.5f);
        }
    }
}
