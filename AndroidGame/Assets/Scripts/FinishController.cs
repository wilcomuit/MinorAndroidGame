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
                dataObject.setFinishedGames(dataObject.getFinishedGames() + 1);
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
