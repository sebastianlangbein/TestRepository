using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static Vector2 screen;
    private static UIManager _uiManagerInstance;

    //properties have the same name as the variable, but with capital letter
    public static UIManager UIManagerInstance
    {
        //read
        get => _uiManagerInstance;

        //write
        private set
        {
            //if _uiManager is not set yet (none have been created before)
            if (_uiManagerInstance == null)
            {
                //sets _uiManagerInstance to value (see awake function)
                _uiManagerInstance = value;
            }
            //if _uiManagerInstance is not equal to value (this; see awake function)
            else if (_uiManagerInstance != value)
            {
                //$ is string formatting
                Debug.Log($"{nameof(UIManager)} instance already exists, destroy dupicate");
                Destroy(value);
            }
        }
    }

    private void Awake()
    {
        //sets value keyword of the UIManagerInstance property to this
        UIManagerInstance = this;
    }

    void Start()
    {
        UpdateUIScale();
    }

    void Update()
    {
        UpdateUIScale();
    }
    public void UpdateUIScale()
    {
        //create a new Vector2 and compare it screen vector2
        //this is so the manager only updates screen vector2 when player resizes the game screen
        if (new Vector2(Screen.width / 16, Screen.height / 9) != screen)
        {
            //set the screen vector2 values as resolution divided by aspectratio
            //this will give the number of pixels in a 16x9 grid based on the game screen size
            screen.x = Screen.width / 16;
            screen.y = Screen.height / 9;
        }
    }
}
