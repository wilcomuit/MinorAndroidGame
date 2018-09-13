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
    public GameObject pickupObject2;
    public GameObject obstacle1;
    public static List<GameObject> pickupList = new List<GameObject>();

    public GameObject background1;
    public GameObject background2;
    public static List<GameObject> backgroundList = new List<GameObject>();

    public GameObject skin1;
    public GameObject skin2;
    public static List<GameObject> skinList = new List<GameObject>();

    public int gold_Probability = 500;
    public int sand_Probability = 150;
    public int diamond_Probability = 0;
    public int empty_Probability = 350;
    public int probability_Multiplier = 1;

    public static int goldProbability;
    public static int sandProbability;
    public static int diamondProbability;
    public static int emptyProbability;
    public static int probabilityMultiplier;

    

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
        pickupList.Add(pickupObject2);
        pickupList.Add(obstacle1);
        prefabEndInstance = prefabEnd;

        skinList.Add(skin1);
        skinList.Add(skin2);


        backgroundList.Add(background1);
        backgroundList.Add(background2);

        goldProbability = gold_Probability;
        sandProbability = sand_Probability;
        diamondProbability = diamond_Probability;
        emptyProbability = empty_Probability;
        probabilityMultiplier = probability_Multiplier;



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
        GameObject.FindGameObjectWithTag("FloorCount").GetComponent<Text>().text = "Floor: "  + amountOfPlatforms;
    }

    public static void updateProbability()
    {
        GameObject.FindGameObjectWithTag("ProbabilityTest").GetComponent<Text>().text = 
            "G: " + goldProbability + "\nD: " + diamondProbability +
            "\nE: " + emptyProbability + "\nS: " + sandProbability;
    }



}
