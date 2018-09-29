using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public int volume = 100;
    public bool showGhost = true;
    public Slider slider;
    public Toggle toggle;
    public InputField input;

	// Use this for initialization
	void Start () {
        Data data = DataDeserializer.Deserialize();
        volume = data.getVolume();
        showGhost = data.getShowGhost();
        slider.value = volume;
        toggle.isOn = showGhost;



        ShowEnabledCheat();
    }

    void ShowEnabledCheat()
    {
        Data data = DataDeserializer.Deserialize();
        GameObject enabledCheat = GameObject.Find("EnabledCheat");
        if (data.getWaterSpeed() == 1f)
        {
            enabledCheat.GetComponent<Text>().text = "enabled cheat: slowater";
        }
        else if (data.getWaterSpeed() == -1f)
        {
            enabledCheat.GetComponent<Text>().text = "enabled cheat: dry";
        } else
        {
            enabledCheat.GetComponent<Text>().text = "";
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnVolumeChanged()
    {
        this.volume = (int) slider.value;
        GameObject.Find("VolumePercentage").GetComponent<Text>().text = this.volume + "%";


        foreach (AudioSource source in AudioController.gObject.GetComponents<AudioSource>())
        {
            source.volume = ((float)this.volume / 100);
        }
    }

    public void OnGhostChanged()
    {
        this.showGhost = toggle.isOn;
    }

    public void SaveAndQuit()
    {
        Data data = DataDeserializer.Deserialize();
        data.setVolume(this.volume);
        data.setShowGhost(this.showGhost);
        DataSerializer.Serialize(data);
        SceneManager.LoadScene("Menu");
    }


    public void OnSubmitCheat()
    {
        Data data = DataDeserializer.Deserialize();
        string cheat = input.text;
        switch (cheat)
        {
            case "hesoyam":
                
                data.setMoney(data.getMoney() + 25000);
                DataSerializer.Serialize(data);
                input.text = "";
                break;
            case "slowater":
                data.setWaterSpeed(1f);
                DataSerializer.Serialize(data);
                input.text = "";
                ShowEnabledCheat();
                break;
            case "ogwater":
                data.setWaterSpeed(2.3f);
                DataSerializer.Serialize(data);
                input.text = "";
                ShowEnabledCheat();
                break;
            case "dry":
                data.setWaterSpeed(-1f);
                DataSerializer.Serialize(data);
                input.text = "";
                ShowEnabledCheat();
                break;
            case "newbeginning":
                string path = Application.persistentDataPath + "/gameData.dat";
                File.Delete(path);
                input.text = "";
                break;
            default:
                break;
        }
    }


}
