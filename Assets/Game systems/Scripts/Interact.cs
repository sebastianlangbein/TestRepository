using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Intro Game Systems/Player/Interact
[AddComponentMenu("Intro PRG/RPG/Player/Interact")]
public class Interact : MonoBehaviour
{
    #region Update
    private void Update()
    {
        //if our interact key is pressed
        if (Input.GetButtonDown("Interact"))
        {
            //create a ray
            Ray _interact;
            //this ray is shooting out from the main cameras screen point center of screen
            _interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            //create hit info
            RaycastHit _hitInfo;
            //if this physics raycast hits something within 10 units
            if (Physics.Raycast(_interact,out _hitInfo,10))
            {
                #region NPC tag
                //and that hits info is tagged NPC
                if (_hitInfo.collider.CompareTag("NPC"))
                {
                    //Debug that we hit a NPC     
                    Debug.Log("NPC");
                }     
                #endregion
                #region Item
                //and that hits info is tagged Item
                if (_hitInfo.collider.CompareTag("Item"))
                {
                    //Debug that we hit an Item   
                    Debug.Log("Item");
                }       
                #endregion
            }
        }
    }
    #endregion
}






