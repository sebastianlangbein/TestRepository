using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class KeyBindManager : MonoBehaviour
{
    [Serializable]
    public struct KeybindUI
    {
        public string inputName;
        public Text labelName;
        public Text keyDisplay;
        public string keyDisplayValue;
        public string keyDefaultValue;
    }
    public KeybindUI[] inputKeys;
    public GameObject keyPrefab;
    public GameObject keyContainer;

    private void Start()
    {
        for (int i = 0; i < inputKeys.Length; i++)
        {
            if (i>0)
            {
                GameObject clone = Instantiate(keyPrefab, keyContainer.transform);
                inputKeys[i].labelName = clone.GetComponent<Text>();
                Text[] compsInChild = clone.GetComponentsInChildren<Text>();
                inputKeys[i].keyDisplay = compsInChild[1];
                clone.GetComponentInChildren<Button>().name = inputKeys[i].inputName;
            }
            inputKeys[i].labelName.text = inputKeys[i].inputName;
            inputKeys[i].keyDisplay.text = inputKeys[i].keyDefaultValue;
        }
    }

    public void ChangeKey(GameObject clickedKey)
    {

    }
}
