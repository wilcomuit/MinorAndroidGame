using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour {

    public static int floors = 0;
    public static float highscore;
    public static float currentTime;
    public static bool finished = false;
    public static bool completed = false;

    public static readonly int ENDLESS = -1;
    public static readonly int FLOORS = 100;

    public static int scoredMoney = 0;

    // Use this for initialization
    void Start () {
        AudioController.ChangingScene();

        GameObject canvas = GameObject.Find("Canvas");
        GameObject scores = GameObject.Find("Scores");
        GameObject times = GameObject.Find("Times");
        if (GameController.gameType == ENDLESS) {
            GameObject.FindGameObjectWithTag("EndGameMessage").GetComponent<Text>().text = (highscore < floors) ? "HIGHSCORE" : "NICE TRY";
            scores.transform.position = new Vector3(canvas.transform.position.x, scores.transform.position.y, scores.transform.position.z);
            times.transform.position = new Vector3(5000f, times.transform.position.y, times.transform.position.z);
        } else {
            times.transform.position = new Vector3(canvas.transform.position.x, times.transform.position.y, times.transform.position.z);
            scores.transform.position = new Vector3(5000f, scores.transform.position.y, scores.transform.position.z);
        }

        GameObject endGameMessage = GameObject.FindGameObjectWithTag("EndGameMessage");
        endGameMessage.GetComponent<Text>().fontSize = 40;

        if (completed && GameController.gameType != ENDLESS)
        {
            GameObject.Find("HighscoreTime").GetComponent<Text>().text = highscore.ToString("0.00");
            GameObject.Find("CurrentTime").GetComponent<Text>().text = currentTime.ToString("0.00");
            if (highscore > currentTime || highscore == 0)
            {
                endGameMessage.GetComponent<Text>().text = "fastest completion";
                GameObject.Find("HighscoreTime").GetComponent<Text>().text = currentTime.ToString("0.00");
            }
            else
            {
                endGameMessage.GetComponent<Text>().text = "successfully completed challenge";
            }
            endGameMessage.GetComponent<Text>().fontSize = 25;
            completed = false;
        } else if (GameController.gameType != ENDLESS)
        {
            times.transform.position = new Vector3(5000f, times.transform.position.y, times.transform.position.z);
            endGameMessage.GetComponent<Text>().text = "better luck next time";
        }

        GameObject.FindGameObjectWithTag("EndGameScore").GetComponent<Text>().text = floors.ToString();
        GameObject.FindGameObjectWithTag("EndGameHighscore").GetComponent<Text>().text = (highscore < floors) ? floors.ToString() : highscore.ToString();
        GameObject.FindGameObjectWithTag("EndGameMoney").GetComponent<Text>().text = DataDeserializer.Deserialize().getMoney().ToString();

        GameObject.Find("MoneyGathered").GetComponent<Text>().text = scoredMoney + "";

        if (scoredMoney == 0)
        {
            GameObject.Find("WatchAd").transform.position = new Vector3(5000, 0, 0);
        }
    }

    public void OnClickAd()
    {
        AdvertisementController.StartAdvertisements();
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;
        Advertisement.Show("rewardedVideo", options);
    }

    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            GameObject.Find("MoneyGathered").GetComponent<Text>().text = (scoredMoney * 2) + "";
            Data data = DataDeserializer.Deserialize();
            data.setMoney(data.getMoney() + scoredMoney);
            DataSerializer.Serialize(data);
            scoredMoney = 0;
            GameObject.Find("WatchAd").transform.position = new Vector3(5000, 0, 0);
            GameObject.FindGameObjectWithTag("EndGameMoney").GetComponent<Text>().text = data.getMoney().ToString();
        }
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
        GameController.amountOfPlatforms = 0;
        GameController.score = 0;
        switch (GameController.gameType)
        {
            case 1:
                GameController.amountOfPlatforms = 0;
                GameController.score = 0;
                SceneManager.LoadScene("Challenge100");
                break;
            case 2:
                GameController.amountOfPlatforms = 0;
                GameController.score = 0;
                SceneManager.LoadScene("Challenge100");
                break;
            case 3:
                GameController.amountOfPlatforms = 0;
                GameController.score = 0;
                SceneManager.LoadScene("Challenge100");
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            default:
                GameController.amountOfPlatforms = 0;
                GameController.score = 0;
                SceneManager.LoadScene("Game");
                break;

        }

    }
}
