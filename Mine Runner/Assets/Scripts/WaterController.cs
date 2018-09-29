using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterController : MonoBehaviour {

    private static Rigidbody2D rb2d;
    private float height;
    private float playerHeight;
    public GameObject player;
    private bool saving = false;
    public static float waterSpeed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        height = GetComponent<BoxCollider2D>().bounds.size.y;
        waterSpeed = DataDeserializer.Deserialize().getWaterSpeed();
        
    }

    public static void StopWater()
    {
        rb2d.velocity = new Vector2(0, 0);
    }

    public static void StartWater()
    {
        waterSpeed = DataDeserializer.Deserialize().getWaterSpeed();
        rb2d.velocity = new Vector2(0, -waterSpeed);
    }

    public static void UpdateWaterSpeed()
    {
        int floors = GameController.amountOfPlatforms;
        int speedUpgrade = (int)Math.Floor((double) floors / 500);
        waterSpeed += speedUpgrade;
    }

    void Update()
    {
        if (gameObject.transform.position.y - (height/2) < player.transform.position.y)
        {
            try
            {
                if (!saving)
                {
                    saving = true;
                    Data dataObject = GameController.dataStorage;
                    int scoredMoney = GameController.score - GameController.startScore;
                    EndGameController.scoredMoney = scoredMoney;
                    dataObject.setMoney(GameController.score);
                    EndGameController.highscore = dataObject.getHighestFloors();
                    EndGameController.floors = GameController.amountOfPlatforms;
                    if (GameController.gameType == -1) EndGameController.finished = false;
                    else EndGameController.finished = true;
                    if (dataObject.getHighestFloors() < GameController.amountOfPlatforms)
                    {
                        dataObject.setHighestFloors(GameController.amountOfPlatforms);
                    }
                    dataObject.setTotalFloors(dataObject.getTotalFloors() + GameController.amountOfPlatforms);
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
}
