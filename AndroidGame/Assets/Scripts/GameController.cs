using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static int score = 0;
    public static Data dataStorage;

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;
    public GameObject prefab7;
    public GameObject prefab8;
    public GameObject prefab9;
    public GameObject prefabEnd;

    public static GameObject prefabEndInstance;

    public static int gameType = -1;
    public static int amountOfPlatforms = 0;
    public static int lastPlatformIndex = -1;
    public static List<GameObject> gameObjectList = new List<GameObject>();

    public GameObject pickupObject1;
    public GameObject obstacle1;
    public static List<GameObject> pickupList = new List<GameObject>();

    public GameObject background1;
    public GameObject background2;
    public GameObject background3;
    public static List<GameObject> backgroundList = new List<GameObject>();

    void Awake()
    {
        dataStorage = DataDeserializer.Deserialize();
        gameObjectList.Add(prefab1);
        gameObjectList.Add(prefab2);
        gameObjectList.Add(prefab3);
        gameObjectList.Add(prefab4);
        gameObjectList.Add(prefab5);
        gameObjectList.Add(prefab6);
        gameObjectList.Add(prefab7);
        gameObjectList.Add(prefab8);
        gameObjectList.Add(prefab9);
        pickupList.Add(pickupObject1);
        pickupList.Add(obstacle1);
        prefabEndInstance = prefabEnd;

        backgroundList.Add(background1);
        backgroundList.Add(background2);
        backgroundList.Add(background3);
    }


    void Start () {
        score = dataStorage.getMoney();
        updateScore();
	}
	
	void Update () {
		
	}

    public static void updateScore()
    {
        GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = "$" + score;
    }

    public static void updateFloorCount()
    {
        GameObject.FindGameObjectWithTag("FloorCount").GetComponent<Text>().text = "Floors: "  + amountOfPlatforms;
    }

    
}
