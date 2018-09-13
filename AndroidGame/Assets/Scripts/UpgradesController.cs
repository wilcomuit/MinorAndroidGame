using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradesController : MonoBehaviour {
    private Data data;
    public int[] priceArray = new int[] { 0, 1, 2 };
    public Sprite[] imageArray = new Sprite[] { };

	// Use this for initialization
	void Start () {
        data = DataDeserializer.Deserialize();
        SetMoney();

        SetCurrent();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetCurrent()
    {
        int multiplier = data.getMoneyMultiplier();
        GameObject gObject = GameObject.Find("PickaxeLevelText");
        gObject.GetComponent<Text>().text = "Pickaxe\nlv. " + multiplier;
        GameObject upgradeButton = GameObject.Find("Upgrade");
        upgradeButton.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject upgradeText = upgradeButton.transform.Find("UpgradeText").gameObject;
        if (multiplier == priceArray.Length)
        {
            upgradeText.GetComponent<Text>().text = "max";
            upgradeText.GetComponent<Text>().fontSize = 10;
            upgradeButton.GetComponent<Image>().color = new Color32(149, 154, 150, 255);
            GameObject.Find("PriceText").GetComponent<Text>().text = "";
        } else if (priceArray[multiplier] > data.getMoney())
        {
            upgradeText.GetComponent<Text>().text = "insufficient";
            upgradeText.GetComponent<Text>().fontSize = 8;
            upgradeButton.GetComponent<Image>().color = new Color32(212, 29, 7, 255);
            GameObject.Find("PriceText").GetComponent<Text>().text = "cost: $" + priceArray[multiplier];
        } else
        {
            upgradeText.GetComponent<Text>().text = "upgrade";
            upgradeText.GetComponent<Text>().fontSize = 10;
            upgradeButton.GetComponent<Image>().color = new Color32(0, 197, 39, 255);
            upgradeButton.gameObject.GetComponent<Button>().onClick.AddListener(() => OnClickMoneyMultiplier(multiplier+1));
            GameObject.Find("PriceText").GetComponent<Text>().text = "cost: $" + priceArray[multiplier];
        }
        GameObject.Find("StatsText").GetComponent<Text>().text = "x " + multiplier + ".0";
        GameObject.Find("PickaxeIcon").GetComponent<Image>().sprite = imageArray[multiplier-1];
    }

    public void OnSkinsClick()
    {
        SceneManager.LoadScene("Customization");
    }

    public void OnBack()
    {
        SceneManager.LoadScene("Menu");
    }

    void SetMoney()
    {
        GameObject.FindGameObjectWithTag("EndGameMoney").GetComponent<Text>().text = "$" + data.getMoney();
    }

    public void OnClickMoneyMultiplier(int index)
    {
        Debug.Log(index);
        int price = priceArray[index - 1];
        Debug.Log(price);
        if (data.getMoney() >= price)
        {
            data.setMoney(data.getMoney() - price);
            data.setMoneyMultiplier(index);
            DataSerializer.Serialize(data);
            SetMoney();
            SetCurrent();
        }
    }
}
