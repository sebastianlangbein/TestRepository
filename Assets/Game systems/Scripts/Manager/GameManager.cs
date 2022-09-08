using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameStates currentState = GameStates.GameState;

    private static GameManager _gameManagerInstance;
    public static GameManager GameManagerInstance
    {
        //get { return _gameManagerInstance; }
        get => _gameManagerInstance;
        private set
        {
            if (_gameManagerInstance == null)
            {
                _gameManagerInstance = value;
            }
            else if (_gameManagerInstance != value)
            {
                Debug.Log($"{nameof(GameManager)} instance already exists, destroy dupicate");
                Destroy(value);
            }
        }
    }
    private void Awake()
    {
        GameManagerInstance = this;
    }

    void Start()
    {
        currentState = GameStates.GameState;
    }
    public void Update()
    {
        switch (currentState)
        {
            case GameStates.GameState:
                if (Cursor.visible == true)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                break;
            case GameStates.MenuState:
                if (Cursor.visible == false)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                break;
            case GameStates.DeathState:
                if (Cursor.visible == true)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                break;
            default:
                break;
        }
    }
}
public enum GameStates
{
    GameState,
    MenuState,
    DeathState
}
