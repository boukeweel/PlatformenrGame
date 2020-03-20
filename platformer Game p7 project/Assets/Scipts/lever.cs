using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class lever : MonoBehaviour
{
    public GameObject leversite1, leversite2, door;
     Player p;

    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            Debug.Log("ja");
            p = other.gameObject.GetComponent<Player>();
            if (XCI.GetButtonDown(XboxButton.X, p.PlayerNumber))
            {
                Debug.Log("kilk");
                leversite1.SetActive(false);
                leversite2.SetActive(true);
                door.SetActive(false);
            }
        }
    }
}
