using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chekpointcol : MonoBehaviour
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
            gm.changeCammera();
            this.gameObject.SetActive(false);
        }
    }
}
