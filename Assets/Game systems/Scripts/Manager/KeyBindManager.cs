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
    private GameObject _currentInput;
    public Color32 changedColour = new Color32(39, 171, 249, 255);
    public Color32 selectedColour = new Color32(239, 116, 36, 255);
    [SerializeField]
    public Dictionary<string, KeyCode> keyBindDict = new Dictionary<string, KeyCode>();

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
            keyBindDict.Add(inputKeys[i].inputName, (KeyCode)Enum.Parse(typeof(KeyCode), inputKeys[i].keyDefaultValue));
        }
    }

    public void ChangeKey(GameObject clickedKey)
    {
        _currentInput = clickedKey;
        if (clickedKey != null)//if we have clicked a keybind button and its registered that its selected
        {
            //change the colour to show the user that it is selected
            _currentInput.GetComponent<Image>().color = selectedColour;
        }
    }

    private void OnGUI()//allows events to run
    {
        string newKey = "";
        Event e = Event.current;
        if (_currentInput != null)
        {
            if (e.isKey)
            {
                newKey = e.keyCode.ToString();
            }
            //if (Input.GetKey(KeyCode.LeftShift))
            //{
            //    newKey = "LeftShift";
            //}
            //if (Input.GetKey(KeyCode.RightShift))
            //{
            //    newKey = "RightShift";
            //}
            if (newKey != "")//if we set a key
            {
                keyBindDict[_currentInput.name] = (KeyCode)Enum.Parse(typeof(KeyCode), newKey);
                _currentInput.GetComponentInChildren<Text>().text = newKey;
                _currentInput.GetComponent<Image>().color = changedColour;
                _currentInput = null;
            }
        }
    }
}
