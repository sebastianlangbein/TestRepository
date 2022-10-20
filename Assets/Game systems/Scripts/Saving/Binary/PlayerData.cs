[System.Serializable]

public class PlayerData
//PlayerData is the bridge between your binary save script and the game
{
    //Data from game that we want to save
    public float posX, posY, posZ;
    public float rotX, rotY, rotZ, rotW;
    public float curHealth, maxHealth, curMana, maxMana, curStam, maxStam, curExp, maxExp;
    public int level;
    public string playerName;

    public PlayerData(PlayerHandler player)
    {
        playerName = player.name;
        level = 1;
        maxHealth = 100;
        curHealth = 100;
        maxStam = 100;
        curStam = 100;
        maxMana = 100;
        curMana = 100;
        maxExp = 50;
        curExp = 0;

        posX = player.transform.position.x;
        posY = player.transform.position.y;
        posZ = player.transform.position.z;

        rotX = player.transform.rotation.x;
        rotY = player.transform.rotation.y;
        rotZ = player.transform.rotation.z;
        rotW = player.transform.rotation.w;
    }
}
