using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataDeserializer : MonoBehaviour {

    private static string destination = Application.persistentDataPath + "/gameData.dat";

    void Start () {
    }

    public static Data Deserialize()
    {
        Data.defaultSkinList.Add(1);
        FileStream file;
        if (File.Exists(destination)) file = File.OpenRead(destination);
        else return Data.defaultData;
        BinaryFormatter bf = new BinaryFormatter();
        Data data = (Data)bf.Deserialize(file);
        file.Close();
        return data;
    }
}
