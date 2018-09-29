using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GhostSerializer : MonoBehaviour
{

    private static string destination;

    void Start()
    {
    }

    public static void Serialize(Ghost ghost, string attachment)
    {
        destination = Application.persistentDataPath +"/" + attachment.Replace("/", "") + ".dat";
        FileStream file;
        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, ghost);
        file.Close();
    }
}
