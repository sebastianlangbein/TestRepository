using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public GameObject[] panels;
    public MenuStates menuState;
    private void Start()
    {
        ChangeMenu(0);
    }
    private void Update()
    {
        if (Input.anyKey && menuState==MenuStates.AnyKey)
        {
            ChangeMenu(1);
        }
    }
    public void ChangeMenu(int state)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
        panels[state].SetActive(true);
        menuState = (MenuStates)state;
    }
}
public enum MenuStates
{
    AnyKey,
    MainMenu,
    Options
}

