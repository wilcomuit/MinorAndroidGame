using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour {

    private bool saving = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        try
        {
            if (!saving)
            {
                saving = true;
                Data dataObject = GameController.dataStorage;
                int scoredMoney = GameController.score - GameController.startScore;
                EndGameController.scoredMoney = scoredMoney;
                dataObject.setMoney( GameController.score + ((int)Math.Floor((double)(scoredMoney / 100 * Globals.challenge_money_Percentage))) + Globals.challenge_Money);
                dataObject.setFinishedGames(dataObject.getFinishedGames() + 1);

                float highscore = dataObject.getHighscores()[GameController.gameType - 1];
                float score = GameController.gameTimer;
                EndGameController.currentTime = score;
                EndGameController.highscore = highscore;
                EndGameController.finished = true;
                EndGameController.completed = true;
                if (highscore > score || highscore == 0)
                {
                    List<float> scores = dataObject.getHighscores();
                    scores[GameController.gameType - 1] = score;
                    dataObject.setHighscores(scores);

                    Ghost ghost = new Ghost(PlayerController.ghostListX, PlayerController.ghostListY, PlayerController.ghostListFlip, PlayerController.ghostListSpeed, dataObject.getSelectedSkin());
                    GhostSerializer.Serialize(ghost, "Challenge" + GameController.gameType);
                }
                DataSerializer.Serialize(dataObject);
                GameController.dataStorage = dataObject;
                GameController.score = 0;
                GameController.amountOfPlatforms = 0;
                saving = false;
            }
        } catch (Exception e) {
            Debug.Log(e.Message);
        } finally {
            saving = false;
            SceneManager.LoadScene("Result");
        }
    }
}
