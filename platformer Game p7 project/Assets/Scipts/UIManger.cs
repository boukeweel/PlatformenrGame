using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManger : MonoBehaviour
{
    public GameObject gamescene;
    public GameObject uiscene;
    
    public GameObject credits;
    public GameObject mainmenu;

    bool _gamescene = false;
    bool _uiscene = false;
    bool _credits = false;
    bool _mainmenu = true;

    private void Start()
    {
        _gamescene = false;
        _uiscene = true;
        _credits = false;
        _mainmenu = true;
    }
    private void Update()
    {

        gamescene.SetActive(_gamescene);
        uiscene.SetActive(_uiscene);
        mainmenu.SetActive(_mainmenu);

        credits.SetActive(_credits);
    }
    public void Start_button()
    {
        //sellect
        FindObjectOfType<audiomanger>().play("sellect");
        FindObjectOfType<audiomanger>().play("birdsounds");
        _gamescene = true;
        _uiscene = false;
        _credits = false;
        _mainmenu = false;
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
        _gamescene = false;
        _uiscene = false;
        _credits = false;
        _mainmenu = true;
        FindObjectOfType<audiomanger>().play("sellect");
    }
    public void CreditsMenu()
    {
        _gamescene = false;
        _uiscene = false;
        _credits = true;
        _mainmenu = false;
        FindObjectOfType<audiomanger>().play("sellect");
    }
    
    
}
