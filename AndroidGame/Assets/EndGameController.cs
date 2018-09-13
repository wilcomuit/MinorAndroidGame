using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour {

    public static int floors = 0;
    public static int highscore = 0;
    public static bool finished = false;

    public static readonly int ENDLESS = -1;
    public static readonly int FLOORS = 100;


    // Use this for initialization
    void Start () {
        GameObject.FindGameObjectWithTag("EndGameMessage").GetComponent<Text>().text = (highscore < floors) ? "HIGHSCORE" : "NICE TRY";
        if (finished)
        {
            GameObject.FindGameObjectWithTag("EndGameMessage").GetComponent<Text>().text = "ESCAPED";
        }
        GameObject.FindGameObjectWithTag("EndGameScore").GetComponent<Text>().text = floors.ToString();
        GameObject.FindGameObjectWithTag("EndGameHighscore").GetComponent<Text>().text = (highscore < floors) ? floors.ToString() : highscore.ToString();
        GameObject.FindGameObjectWithTag("EndGameMoney").GetComponent<Text>().text = "$" + DataDeserializer.Deserialize().getMoney();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickBack()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnClickReplay()
    {
        GameController.gameType = (finished) ? FLOORS : ENDLESS;
        GameController.amountOfPlatforms = 0;
        GameController.score = 0;
        SceneManager.LoadScene("Game");
    }
}
