using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChallengesController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Data data = DataDeserializer.Deserialize();

        string highscore1 = data.getHighscores()[0].ToString("0.00");
        string highscore2 = data.getHighscores()[1].ToString("0.00");
        string highscore3 = data.getHighscores()[2].ToString("0.00");

        if (!highscore1.Equals("0.00"))
            GameObject.Find("Highscore1").GetComponent<Text>().text = "highscore:\n" + highscore1;
        
        if (!highscore2.Equals("0.00"))
            GameObject.Find("Highscore2").GetComponent<Text>().text = "highscore:\n" + highscore2;
        
        if (!highscore3.Equals("0.00"))
            GameObject.Find("Highscore3").GetComponent<Text>().text = "highscore:\n" + highscore3;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickChallenge(int index)
    {
        switch (index)
        {
            case 1:
                GameController.gameType = index;
                if (GhostDeserializer.Deserialize("Challenge" + index).getGhostPlayerX().Count == 0) SceneManager.LoadScene("Instructions");
                else SceneManager.LoadScene("Challenge100");
                break;
            case 2:
                GameController.gameType = index;
                if (GhostDeserializer.Deserialize("Challenge" + index).getGhostPlayerX().Count == 0) SceneManager.LoadScene("Instructions");
                else SceneManager.LoadScene("Challenge100");
                break;
            case 3:
                GameController.gameType = index;
                if (GhostDeserializer.Deserialize("Challenge" + index).getGhostPlayerX().Count == 0) SceneManager.LoadScene("Instructions");
                else SceneManager.LoadScene("Challenge100");
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            default:
                break;
        }
    }


    public void OnClickBack()
    {
        SceneManager.LoadScene("Menu");
    }
}
