using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public int witchlever = 0;
    public int howmanytimes;
    public GameObject text1, text2,text3;
    bool eenkeer;
    bool duursleuten;
    

    //open the door with lever
    public void OpDoor()
    {
        lever[witchlever].SetActive(false);
        lever[witchlever + 1].SetActive(true);
        doors[witchdoor].SetActive(false);
        if(eenkeer == false)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            eenkeer = true;
        }
        duursleuten = true;
        
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
            howmanytimes += 1;
            if(howmanytimes == 3)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                cameras[cameraone].SetActive(false);
                cameras[cameratwo].SetActive(true);
                cameraone += 1;
                cameratwo += 1;
                testint = 1;
                test = false;
                witchlever += 2;
            }
            
            
        }
        
        
    }
    //close the door after player whent true
    public void closedoor()
    {
        if(duursleuten == true)
        {
            doors[witchdoor].SetActive(true);
            witchdoor += 1;
            testint = 0;
            duursleuten = false;
        }
        
        
        
    }
    


}
