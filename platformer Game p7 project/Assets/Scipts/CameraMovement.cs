using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float speed = 1;
    public Transform Player;
    

    private void Start()
    {
        
    }
    private void Update()
    {
        
        transform.Translate(new Vector3(1 * Time.deltaTime * speed, 0, 0));
    }
}
