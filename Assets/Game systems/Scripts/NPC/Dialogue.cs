using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script can be found in the Component section under the option NPC/Dialogue
public class Dialogue : MonoBehaviour
{
    #region Variables
    [Header("Variables")]
    //boolean to toggle if we can see a characters dialogue box
    public bool showDialogue;
    //index for our current line of dialogue and an index for a set question marker of the dialogue
    public int index;
    [Header("NPC Name and Dialogue")]
    //name of this specific NPC
    public string charName;
    //array for text for our dialogue
    public string[] dialogue;
    #endregion

    #region OnGUI
    private void OnGUI()
    {
        //if our dialogue can be seen on screen
        if (showDialogue)
        {
            //the dialogue box takes up the whole bottom 3rd of the screen and displays the NPC's name and current dialogue line
            GUI.Box(new Rect(0,6*UIManager.screen.y,Screen.width,3*UIManager.screen.y), $"{charName}: {dialogue[index]}");

            //if not at the end of the dialogue
            if (index < dialogue.Length-1)
            {
                //next button allows us to skip forward to the next line of dialogue
                if (GUI.Button(new Rect(13.5f * UIManager.screen.x, 8.25f * UIManager.screen.y,
                    2.5f * UIManager.screen.x, .75f * UIManager.screen.y), "Next"))
                {

                }
            }
            //else if we are at options
            else
            {
                //the Bye button allows up to end our dialogue
                if (GUI.Button(new Rect(13.5f * UIManager.screen.x, 8.25f * UIManager.screen.y,
                    2.5f * UIManager.screen.x, .75f * UIManager.screen.y), "Bye"))
                {
                    //close the dialogue box
                    showDialogue = false;
                    //set index back to 0 
                    index = 0;
                    //change state
                }
                //lock the mouse cursor
                //set the cursor to being invisible
            }
        }
    }
    #endregion
}
