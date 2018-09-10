using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour {



	// Use this for initialization
	void Start () {
        updateHighscore();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void updateHighscore()
    {
        Data savedData = DataDeserializer.Deserialize();
        if (savedData != null)
        {
            GameObject.FindGameObjectWithTag("Highscore").GetComponent<Text>().text = savedData.getHighestFloors() + "";
        }
    }
}
