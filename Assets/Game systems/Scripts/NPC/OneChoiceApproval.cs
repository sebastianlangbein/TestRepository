using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneChoiceApproval : OneChoice
{
    [Header("How much the NPC likes us")]
    public int approval;
    [Header("The dialogue based on approval")]
    public string[] likeText;
    public string[] neutralText;
    public string[] dislikeText;

    private void Start()
    {
        approval = 0;
        ChangeDialogue(approval);
    }
    private void ChangeDialogue(int approval)
    {
        switch (approval)
        {
            case -1:
                dialogue = dislikeText;
                break;
            case 0:
                dialogue = neutralText;
                break;
            case 1:
                dialogue = likeText;
                break;
        }
    }
    private void OnGUI()
    {
        if (showDialogue)
        {
            //the dialogue box takes up the whole bottom 3rd of the screen and displays the NPC's name and current dialogue line
            GUI.Box(new Rect(0, 6 * UIManager.screen.y, Screen.width, 3 * UIManager.screen.y), $"{charName}: {dialogue[index]}");

            //if not at the end of the dialogue
            if (index < dialogue.Length - 1 && index != choiceIndex)
            {
                //next button allows us to skip forward to the next line of dialogue
                if (GUI.Button(new Rect(13.5f * UIManager.screen.x, 8.25f * UIManager.screen.y,
                    2.5f * UIManager.screen.x, .75f * UIManager.screen.y), "Next"))
                {
                    index++;
                }
            }

            else if (index == choiceIndex)
            {
                if (GUI.Button(new Rect(11f * UIManager.screen.x, 8.25f * UIManager.screen.y,
                    2.5f * UIManager.screen.x, .75f * UIManager.screen.y), "Yes"))
                {
                    index++;
                    if (approval < 1)
                    {
                        approval++;
                    }
                    ChangeDialogue(approval);
                }

                if (GUI.Button(new Rect(13.5f * UIManager.screen.x, 8.25f * UIManager.screen.y,
                    2.5f * UIManager.screen.x, .75f * UIManager.screen.y), "No"))
                {
                    index = dialogue.Length - 1;
                    if (approval > -1)
                    {
                        approval--;
                    }
                    ChangeDialogue(approval);
                }
            }
            //else if we are at options
            else
            {
                EndDialogue();
            }
        }
    }
}
