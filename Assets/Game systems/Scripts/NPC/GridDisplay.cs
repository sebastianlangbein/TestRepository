using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDisplay : MonoBehaviour
{

    //OnGUI spelling is specific
    //allows IMGUI - immediate mode GUI
    //Events
    private void OnGUI()
    {
        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                //create a GUI Box
                //Rect is made up of 4 values, (x start, y start, x size, y size)
                //final part is display content
                GUI.Box(new Rect(x*UIManager.screen.x,y*UIManager.screen.y,UIManager.screen.x,UIManager.screen.y), "");
            }
        }
    }
}
