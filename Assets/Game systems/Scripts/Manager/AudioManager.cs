using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _audioManagerInstance;

    //properties have the same name as the variable, but with capital letter
    public static AudioManager AudioManagerInstance
    {
        //read
        get => _audioManagerInstance;

        //write
        private set
        {
            //if _uiManager is not set yet (none have been created before)
            if (_audioManagerInstance == null)
            {
                //sets _uiManagerInstance to value (see awake function)
                _audioManagerInstance = value;
            }
            //if _uiManagerInstance is not equal to value (this; see awake function)
            else if (_audioManagerInstance != value)
            {
                //$ is string formatting
                Debug.Log($"{nameof(AudioManager)} instance already exists, destroy dupicate");
                Destroy(value.gameObject);
            }
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
