using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closedoorcols : MonoBehaviour
{
    private GameManger gm;

    private void Start()
    {
        gm = GetComponentInParent<GameManger>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("ditwerkt?");
            gm.closedoor();
            this.gameObject.SetActive(false);
        }
    }
}
