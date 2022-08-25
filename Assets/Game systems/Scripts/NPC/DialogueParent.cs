using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParent : MonoBehaviour
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
    public void EndDialogue()
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
            GameManager.GameManagerInstance.currentState = GameStates.GameState;
        }
    }
}
