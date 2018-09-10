using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    // Use this for initialization
    public static readonly int ENDLESS = -1;
    public static readonly int FLOORS = 100;

    public static float savedSpeed = 0;
    public static float savedWaterSpeed = 0;
    public static bool paused = false;

    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {


    }

    public void OnPauseClick()
    {
        if (paused)
        {
            PlayerController.speed = savedSpeed;
            WaterController.StartWater();
            savedSpeed = 0;
            paused = false;
        } else {
            savedSpeed = PlayerController.speed;
            PlayerController.speed = 0;
            WaterController.StopWater();
            paused = true;
        }
        
    }

    public void OnMouseUp()
    {
        switch (gameObject.tag)
        {
            case "Endless":
                GameController.gameType = ENDLESS;
                GameController.amountOfPlatforms = 0;
                GameController.score = 0;
                SceneManager.LoadScene("Game");
                break;
            case "Play":
                GameController.gameType = FLOORS;
                GameController.amountOfPlatforms = 0;
                GameController.score = 0;
                if (DataDeserializer.Deserialize().getHighestFloors() == 0) SceneManager.LoadScene("Instructions");
                else SceneManager.LoadScene("Game");
                break;
            case "Settings":
                //SceneManager.LoadScene("Game");
                break;
            case "Customize":
                SceneManager.LoadScene("Customization");
                break;
            default:
                break;

        }
    }
}
