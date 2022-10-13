using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamplePlayerPrefs : MonoBehaviour
{
    /*
    PlayerPrefs (RegEdit)

    Pros
        - Pre-built
            has searching built in, just use key words
            easy to use functions
        - Similar to dictionary with keys and values

    Cons
        - Only saves int, float and string, not bools
        - The save and load functions only read/write one value at a time
        - Saves to a single file location
        - Easily found and edited
        - WebPlayer has a PlayerPrefs size limit of 1MB

    What is it good for?
        - User/Option Settings
            - Controls
            - Audio
            - Resolution

     */
    public string example;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            //Set = Write = Save
            //Sets the value of the preference identified by key
            PlayerPrefs.SetString("Test String", example);
            //Writes all modified preferences to disk
            PlayerPrefs.Save();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            //Removes all keys and values from the reference. Use with caution
            PlayerPrefs.DeleteAll();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            //Removes key and its corresponding value from the preferences
            PlayerPrefs.DeleteKey("Test String");
        }
    }
    private void Awake()
    {
        //HasKey searches for a matching string key(entry) name
        //returns true if key exists in the preferences
        if (PlayerPrefs.HasKey("Test String"))
        {
            Debug.Log("Test String found");
        }
        else
        {
            Debug.Log("No save data");
        }
    }

    private void Start()
    {
        example = PlayerPrefs.GetString("Test String","umbrella");
    }
}
