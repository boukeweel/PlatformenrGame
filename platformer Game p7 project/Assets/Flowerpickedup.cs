using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowerpickedup : MonoBehaviour
{
    public int hoeveel_opgepakt;

    bool eenkeer = false;
    

    public void addPoint()
    {
        if (eenkeer == true)
        {
            hoeveel_opgepakt += 1;
            eenkeer = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bloem"))
        {
            eenkeer = true;
            addPoint();
            Destroy(other.gameObject);
        }
    }
}
