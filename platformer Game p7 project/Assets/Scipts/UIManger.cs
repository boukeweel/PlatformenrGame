using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManger : MonoBehaviour
{
    public GameObject gamescene;
    public GameObject uiscene;
    
    public GameObject credits;
    public GameObject mainmenu;

    private void Start()
    {
        gamescene.SetActive(false);
        uiscene.SetActive(true);
        mainmenu.SetActive(true);

        credits.SetActive(false);
    }
    public void Start_button()
    {
        //sellect
        FindObjectOfType<audiomanger>().play("sellect");
        FindObjectOfType<audiomanger>().play("birdsounds");
        gamescene.SetActive(true);
        uiscene.SetActive(false);
    }
    public void Exit_button()
    {
        Application.Quit();
    }
    public void OnApplicationQuit()
    {
        FindObjectOfType<audiomanger>().play("sellect");
    }
    public void backtomenu()
    {
        gamescene.SetActive(false);
        uiscene.SetActive(true);
        mainmenu.SetActive(true);
        
        credits.SetActive(false);
        FindObjectOfType<audiomanger>().play("sellect");
    }
    public void CreditsMenu()
    {
        mainmenu.SetActive(false);
        credits.SetActive(true);
        FindObjectOfType<audiomanger>().play("sellect");
    }
    
    
}
