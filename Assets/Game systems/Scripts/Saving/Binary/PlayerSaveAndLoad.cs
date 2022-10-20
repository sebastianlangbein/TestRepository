using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveAndLoad : MonoBehaviour
{
    public static PlayerHandler player;

    public static void Save()
    {
        PlayerBinary.SaveData(player);
    }

    public static void Load()
    {
        player.gameObject.GetComponent<CharacterController>().enabled = false;
        PlayerData data = PlayerBinary.LoadData(player);
        player.name = data.playerName;
        //health, mana, stamina, exp, levels
        player.transform.position = new Vector3(data.posX, data.posY, data.posZ);
        player.transform.rotation = new Quaternion(data.rotX, data.rotY, data.rotZ, data.rotW);
        player.gameObject.GetComponent<CharacterController>().enabled = true;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Load();
        }
    }
}
