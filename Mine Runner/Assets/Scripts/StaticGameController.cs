using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StaticGameController : MonoBehaviour {

    public static Data dataStorage;
    public static float savedSpeed = 0;
    public static float savedWaterSpeed = 0;
    public static bool paused = false;


    // Use this for initialization
    void Start () {
        dataStorage = DataDeserializer.Deserialize();
    }
	
	// Update is called once per frame
	void Update () {
        GameController.score = dataStorage.getMoney();
        updateScore();
    }

    public static void updateScore()
    {
        GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = "    " + GameController.score;
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
            savedSpeed = 0;
            paused = false;
            pauseMenu.transform.position = new Vector3(5000f, pauseMenu.transform.position.y, pauseMenu.transform.position.z);
            optionsMenu.transform.position = new Vector3(5000f, optionsMenu.transform.position.y, optionsMenu.transform.position.z);
        }
        else
        {
            savedSpeed = PlayerController.speed;
            PlayerController.speed = 0;
            WaterController.StopWater();
            paused = true;
            pauseMenu.transform.position = new Vector3(canvas.transform.position.x, pauseMenu.transform.position.y, pauseMenu.transform.position.z);
        }

    }
}
