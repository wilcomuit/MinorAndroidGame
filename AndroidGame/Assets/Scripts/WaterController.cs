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
    public static float waterSpeed = 2.3f;
    public float initialWaterSpeed = (float) 2.3;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        height = GetComponent<Renderer>().bounds.size.y;
        waterSpeed = initialWaterSpeed;
        rb2d.velocity = new Vector2(0, -waterSpeed);
        StartWater();
    }

    public static void StopWater()
    {
        rb2d.velocity = new Vector2(0, 0);
    }

    public static void StartWater()
    {
        
        rb2d.velocity = new Vector2(0, -waterSpeed);
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
                    dataObject.setMoney(GameController.score);
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
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
