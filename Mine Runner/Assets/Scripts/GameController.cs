using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static int score = 0;
    public static int startScore = 0;
    public static Data dataStorage;
    public static float savedSpeed = 0;
    public static float savedWaterSpeed = 0;
    public static bool paused = false;

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

    public GameObject highscorePrefab;
    public static GameObject highscorePrefabInstance;
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

    public static int highscore;
    public static bool highscoreShown;

    public static float gameTimer;

    public Sprite jumpButton;
    public Sprite dashButton;
    public Sprite pickupButton;

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
        highscorePrefabInstance = highscorePrefab;

        skinList.Add(skin1);
        skinList.Add(skin2);


        backgroundList.Add(background1);
        backgroundList.Add(background2);

        goldProbability = gold_Probability;
        sandProbability = sand_Probability;
        diamondProbability = diamond_Probability;
        emptyProbability = empty_Probability;
        probabilityMultiplier = probability_Multiplier;


        AudioController.ChangingScene();
    }


    void Start () {
        score = dataStorage.getMoney();
        startScore = dataStorage.getMoney();
        highscore = dataStorage.getHighestFloors();
        highscoreShown = (highscore <= 6);
        updateScore();

 
        switch (dataStorage.getSelectedAbility())
        {
            case 1:
                GameObject.Find("Dash").GetComponent<Image>().sprite = jumpButton;
                break;
            case 2:
                GameObject.Find("Dash").GetComponent<Image>().sprite = dashButton;
                break;
            case 3:
                GameObject.Find("Dash").GetComponent<Image>().sprite = pickupButton;
                break;
            default:
                GameObject.Find("Dash").transform.position = new Vector3(5000f, 5000f, 0);
                break;
        }
            
        

        gameTimer = 0;
	}
	
	void Update () {
        if (!paused)
        {
            gameTimer += Time.deltaTime;
        }
	}

    public static void updateScore()
    {
        GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = "    " + score;
    }

    public static void updateFloorCount()
    {
        GameObject.FindGameObjectWithTag("FloorCount").GetComponent<Text>().text = "Floor: " + amountOfPlatforms;
    }

    public static void updateProbability()
    {
        GameObject probabilityTest = GameObject.FindGameObjectWithTag("ProbabilityTest");
        if (probabilityTest != null)
        {
            probabilityTest.GetComponent<Text>().text =
            "G: " + goldProbability + "\nD: " + diamondProbability +
            "\nE: " + emptyProbability + "\nS: " + sandProbability;
        }
    }


    public void UnpauseGame()
    {
        OnPauseClick();
    }

    public void ClickOptions()
    {
        GameObject optionsMenu = GameObject.Find("OptionsMenu");
        GameObject canvas = GameObject.Find("Canvas");
        optionsMenu.transform.position = new Vector3(canvas.transform.position.x, optionsMenu.transform.position.y, optionsMenu.transform.position.z);
    }

    public void QuitToMenu()
    {
        paused = false;
        SceneManager.LoadScene("Menu");
    }

    public void OnPauseClick()
    {
        GameObject pauseMenu = GameObject.Find("PauseMenu");
        GameObject canvas = GameObject.Find("Canvas");
        GameObject optionsMenu = GameObject.Find("OptionsMenu");

        if (paused)
        {
            PlayerController.speed = savedSpeed;
            WaterController.StartWater();
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().simulated = true;
            savedSpeed = 0;
            paused = false;
            pauseMenu.transform.position = new Vector3(5000f, pauseMenu.transform.position.y, pauseMenu.transform.position.z);
            optionsMenu.transform.position = new Vector3(5000f, optionsMenu.transform.position.y, optionsMenu.transform.position.z);
        }
        else
        {
            savedSpeed = PlayerController.speed;
            PlayerController.speed = 0;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().simulated = false;
            WaterController.StopWater();
            paused = true;
            pauseMenu.transform.position = new Vector3(canvas.transform.position.x, pauseMenu.transform.position.y, pauseMenu.transform.position.z);
        }

    }


}
