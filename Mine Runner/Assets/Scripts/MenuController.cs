using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    // Use this for initialization
    public static readonly int ENDLESS = -1;
    public static readonly int FLOORS = 100;

    public static bool optionsShown = false;

    void Awake () {
        ShowMenu();
        AudioController.ChangingScene();
        AdvertisementController.StartAdvertisements();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name.Equals("Menu")) { Application.Quit(); }

    }


    public void OnEndlessClick()
    {
        GameController.gameType = ENDLESS;
        GameController.amountOfPlatforms = 0;
        GameController.score = 0;
        if (DataDeserializer.Deserialize().getHighestFloors() == 0) SceneManager.LoadScene("Instructions");
        else SceneManager.LoadScene("Game");
    }

    public void OnPlayClick()
    {
        GameController.amountOfPlatforms = 0;
        GameController.score = 0;
        //if (DataDeserializer.Deserialize().getHighestFloors() == 0) SceneManager.LoadScene("Instructions");
        //else SceneManager.LoadScene("Game");
        SceneManager.LoadScene("Challenge");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

    public void OnMouseUp()
    {
        switch (gameObject.tag)
        {
            case "Customize":
                SceneManager.LoadScene("Customization");
                break;
            default:
                break;

        }
    }

    public void OnOptionsClick()
    {
        optionsShown = false;
        SceneManager.LoadScene("Options");
    }


    public void ShowMenu()
    {
        GameObject settings = GameObject.Find("Settings");
        GameObject options = GameObject.Find("Options");
        GameObject leave = GameObject.Find("Leave");
        if (optionsShown)
        {
            leave.transform.position = new Vector3(settings.transform.position.x + 5000f, leave.transform.position.y, leave.transform.position.z);
            options.transform.position = new Vector3(settings.transform.position.x + 5000f, options.transform.position.y, options.transform.position.z);
        }
        else
        {
            leave.transform.position = new Vector3(settings.transform.position.x, leave.transform.position.y, leave.transform.position.z);
            options.transform.position = new Vector3(settings.transform.position.x, options.transform.position.y, options.transform.position.z);
        }
        optionsShown = !optionsShown;
    }
}
