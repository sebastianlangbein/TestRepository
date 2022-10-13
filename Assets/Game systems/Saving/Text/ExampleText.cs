using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class ExampleText : MonoBehaviour
{
    public string[] example;
    public string[] example2;
    string path = "Assets/Game systems/Resources/Save/SaveDataExample.txt";

    //void CreateAndOrWriteText()
    //{
    //    //create file if the path does not exist

    //    if (!File.Exists(path))
    //    {
    //        File.WriteAllText(path, "test");
    //    }
    //}

    void Write()
    {
        //Writer
        //                                           true = append
        //                                           false = replace
        StreamWriter writer = new StreamWriter(path, false);
        for (int i = 0; i < example.Length; i++)
        {
            if (i < example.Length - 1)
            {
                writer.Write(example[i] + "|");
            }
            else
            {
                writer.Write(example[i]);
            }
        }
        writer.Close();
        AssetDatabase.ImportAsset(path);
    }

    void Read()
    {
        //Reader
        StreamReader reader = new StreamReader(path);
        //example2 = reader.ReadLine();  //this reads a single line
        string tempRead = reader.ReadLine();
        example2 = tempRead.Split("|");

        reader.Close();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Read();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            Write();
        }
    }
}
