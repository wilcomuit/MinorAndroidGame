using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GhostDeserializer : MonoBehaviour
{

    private static string destination;


    public static Ghost Deserialize(string attachment)
    {
        destination = Application.persistentDataPath + "/" + attachment.Replace("/","") + ".dat";
        FileStream file;
        if (File.Exists(destination)) file = File.OpenRead(destination);
        else return Ghost.defaultData;
        BinaryFormatter bf = new BinaryFormatter();
        Ghost ghost = (Ghost)bf.Deserialize(file);
        file.Close();
        return ghost;
    }
}
