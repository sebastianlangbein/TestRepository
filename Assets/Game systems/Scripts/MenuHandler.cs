using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (menuState == MenuStates.AnyKey)
        {
            if (Input.anyKey)
            {
                ChangeMenu(1);
            }
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
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
public enum MenuStates
{
    AnyKey,
    MainMenu,
    Options
}

