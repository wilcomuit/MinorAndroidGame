using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradesController : MonoBehaviour {
    private Data data;
    public int[] priceArrayPickaxe = new int[] { 0, 250, 500, 750, 1000, 1250, 1500 };
    public Sprite[] pickaxeImageArray = new Sprite[7] { null, null, null, null, null, null, null };
    public int[] priceArrayBoots = new int[] { 0, 750, 1250 };
    public Sprite[] bootsImageArray = new Sprite[3] { null, null, null };

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
        SeteCurrentPickaxe();
        SetCurrentBoots();
    }

    void SeteCurrentPickaxe()
    {
        data = DataDeserializer.Deserialize();
        int moneyMultiplier = data.getMoneyMultiplier();
        GameObject gObject = GameObject.Find("PickaxeLevelText");
        gObject.GetComponent<Text>().text = "Pickaxe\nlv. " + moneyMultiplier;
        GameObject upgradePickaxe = GameObject.Find("UpgradePickaxe");
        upgradePickaxe.GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject upgradePickaxeText = GameObject.Find("UpgradePickaxeText");
        if (moneyMultiplier == priceArrayPickaxe.Length)
        {
            upgradePickaxeText.GetComponent<Text>().text = "max";
            upgradePickaxeText.GetComponent<Text>().fontSize = 10;
            upgradePickaxe.GetComponent<Image>().color = new Color32(149, 154, 150, 255);
            GameObject.Find("PickaxePriceText").GetComponent<Text>().text = "";
        } else if (priceArrayPickaxe[moneyMultiplier] > data.getMoney())
        {
            upgradePickaxeText.GetComponent<Text>().text = "insufficient";
            upgradePickaxeText.GetComponent<Text>().fontSize = 8;
            upgradePickaxe.GetComponent<Image>().color = new Color32(212, 29, 7, 255);
            GameObject.Find("PickaxePriceText").GetComponent<Text>().text = "cost: $" + priceArrayPickaxe[moneyMultiplier];
        } else
        {
            upgradePickaxeText.GetComponent<Text>().text = "upgrade";
            upgradePickaxeText.GetComponent<Text>().fontSize = 10;
            upgradePickaxe.GetComponent<Image>().color = new Color32(0, 197, 39, 255);
            upgradePickaxe.GetComponent<Button>().onClick.AddListener(() => OnClickMoneyMultiplier(moneyMultiplier + 1));
            GameObject.Find("PickaxePriceText").GetComponent<Text>().text = "cost: $" + priceArrayPickaxe[moneyMultiplier];
        }
        GameObject.Find("PickaxeGoldStatsText").GetComponent<Text>().text = "$" + PlayerController.GetGoldValue(moneyMultiplier);
        GameObject.Find("PickaxeDiamondStatsText").GetComponent<Text>().text = "$" + PlayerController.GetDiamondValue(moneyMultiplier);
        GameObject.Find("PickaxeIcon").GetComponent<Image>().sprite = pickaxeImageArray[moneyMultiplier - 1];
    }


    void SetCurrentBoots()
    {
        data = DataDeserializer.Deserialize();
        int speedMultiplier = data.getSpeedMultiplier();
        GameObject.Find("BootsLevelText").GetComponent<Text>().text = "Boots\nlv. " + speedMultiplier;
        GameObject upgradeBoots = GameObject.Find("UpgradeBoots");
        upgradeBoots.GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject upgradeBootsText = GameObject.Find("UpgradeBootsText");
        if (speedMultiplier == priceArrayBoots.Length)
        {
            upgradeBootsText.GetComponent<Text>().text = "max";
            upgradeBootsText.GetComponent<Text>().fontSize = 10;
            upgradeBoots.GetComponent<Image>().color = new Color32(149, 154, 150, 255);
            GameObject.Find("BootsPriceText").GetComponent<Text>().text = "";
        }
        else if (priceArrayBoots[speedMultiplier] > data.getMoney())
        {
            upgradeBootsText.GetComponent<Text>().text = "insufficient";
            upgradeBootsText.GetComponent<Text>().fontSize = 8;
            upgradeBoots.GetComponent<Image>().color = new Color32(212, 29, 7, 255);
            GameObject.Find("BootsPriceText").GetComponent<Text>().text = "cost: $" + priceArrayBoots[speedMultiplier];
        }
        else
        {
            upgradeBootsText.GetComponent<Text>().text = "upgrade";
            upgradeBootsText.GetComponent<Text>().fontSize = 10;
            upgradeBoots.GetComponent<Image>().color = new Color32(0, 197, 39, 255);
            GameObject.Find("UpgradeBoots").GetComponent<Button>().onClick.AddListener(() => OnClickSpeedMultiplier(speedMultiplier + 1));
            GameObject.Find("BootsPriceText").GetComponent<Text>().text = "cost: $" + priceArrayBoots[speedMultiplier];
        }
        GameObject.Find("BootsStatsText").GetComponent<Text>().text = "speed " +speedMultiplier;
        GameObject.Find("BootsIcon").GetComponent<Image>().sprite = bootsImageArray[speedMultiplier - 1];
    }

    public void OnSkinsClick()
    {
        SceneManager.LoadScene("Customization");
    }

    public void OnClickAbilities()
    {
        SceneManager.LoadScene("Abilities");
    }

    public void OnBack()
    {
        SceneManager.LoadScene("Menu");
    }

    void SetMoney()
    {
        GameObject.FindGameObjectWithTag("EndGameMoney").GetComponent<Text>().text = data.getMoney().ToString();
    }

    public void OnClickMoneyMultiplier(int index)
    {
        int price = priceArrayPickaxe[index - 1];
        if (data.getMoney() >= price)
        {
            data.setMoney(data.getMoney() - price);
            data.setMoneyMultiplier(index);
            DataSerializer.Serialize(data);
            SetMoney();
            SetCurrent();
        }
    }

    public void OnClickSpeedMultiplier(int index)
    {
        int price = priceArrayBoots[index - 1];
        if (data.getMoney() >= price)
        {
            data.setMoney(data.getMoney() - price);
            data.setSpeedMultiplier(index);
            DataSerializer.Serialize(data);
            SetMoney();
            SetCurrent();
        }
    }
}
