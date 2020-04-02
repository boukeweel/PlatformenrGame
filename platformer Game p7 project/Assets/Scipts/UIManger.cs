using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManger : MonoBehaviour
{
    public GameObject GameScene;
    public GameObject Uiscene;

    private void Start()
    {
        GameScene.SetActive(false);
        Uiscene.SetActive(true);
    }
    public void Start_button()
    {
        GameScene.SetActive(true);
        Uiscene.SetActive(false);
    }
    public void Exit_button()
    {
        Application.Quit();
    }
    public void backtomenu()
    {
        GameScene.SetActive(false);
        Uiscene.SetActive(true);
    }
}
