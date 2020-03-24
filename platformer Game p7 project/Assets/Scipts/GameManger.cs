using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public List<GameObject> cameras;
    public int cameraone = 0;
    public int cameratwo = 1;
    public List<GameObject> lever;
    public List<GameObject> doors;
    public int witchdoor = 0;
    bool test;
    int testint;

    //open the door with lever
    public void OpDoor()
    {
        lever[0].SetActive(false);
        lever[1].SetActive(true);
        doors[witchdoor].SetActive(false);
    }
    //change the cammera vieuw if you go true the door
    public void changeCammera()
    {
        if (testint == 0)
        {
            test = true;
        }
        if(test == true)
        {
            cameras[cameraone].SetActive(false);
            cameras[cameratwo].SetActive(true);
            cameraone += 1;
            cameratwo += 1;
            testint = 1;
            test = false;
        }
        
        
    }
    //close the door after player whent true
    public void closedoor()
    {
        doors[witchdoor].SetActive(true);
        witchdoor += 1;
        testint = 0;
    }


}
