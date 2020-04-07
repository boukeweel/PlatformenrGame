using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManger : MonoBehaviour
{
    public GameObject gamescene;
    public GameObject uiscene;
    public GameObject setting;
    public GameObject credits;
    public GameObject mainmenu;

    private void Start()
    {
        gamescene.SetActive(false);
        uiscene.SetActive(true);
        mainmenu.SetActive(true);
        setting.SetActive(false);
        credits.SetActive(false);
    }
    public void Start_button()
    {
        gamescene.SetActive(true);
        uiscene.SetActive(false);
    }
    public void Exit_button()
    {
        Application.Quit();
    }
    public void backtomenu()
    {
        gamescene.SetActive(false);
        uiscene.SetActive(true);
        mainmenu.SetActive(true);
        setting.SetActive(false);
        credits.SetActive(false);
    }
    public void CreditsMenu()
    {
        mainmenu.SetActive(false);
        credits.SetActive(true);
    }
    public void SettingsMenu()
    {
        mainmenu.SetActive(false);
        setting.SetActive(true);
    }
    
}
