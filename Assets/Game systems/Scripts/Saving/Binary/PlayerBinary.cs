using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class PlayerBinary
{
    public static void SaveData(PlayerHandler player)
    {
        //Reference to binary formatter
        BinaryFormatter formatter = new BinaryFormatter();
        //location to save (file path)
        string path = Application.persistentDataPath + "/" + "dog_pic" + ".jpeg";
        //create/replace a file at the file path
        FileStream writeDataStream = new FileStream(path, FileMode.Create);
        //what data to write to the file
        PlayerData data = new PlayerData(player);
        //write that data from the serialized byte stream (the unity data
        //that we have converted to bytes wo we can save it to file)
        formatter.Serialize(writeDataStream, data);
        //close the byte stream and finish writing
        writeDataStream.Close();
    }
    public static PlayerData LoadData(PlayerHandler player)
    {
        //location to save (file path)
        string path = Application.persistentDataPath + "/" + "dog_pic" + ".jpeg";
        //if we have a file at that path
        if (File.Exists(path))
        {
            //Reference formatter
            BinaryFormatter formatter = new BinaryFormatter();
            //open file at file path
            FileStream readDataStream = new FileStream(path, FileMode.Open);
            //read data from the file and deserialize it (turn bytes back into c# data for unity)
            PlayerData data = formatter.Deserialize(readDataStream) as PlayerData;
            //close the byte stream and finish reading
            readDataStream.Close();
            //send the usable data to the PlayerData script
            return data;
        }
        return null;
    }
}
