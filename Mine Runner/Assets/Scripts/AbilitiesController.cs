using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AbilitiesController : MonoBehaviour {

    public int[] priceArray = new int[] { 250, 250, 250, 250, 250 };

    private Data data;

    // Use this for initialization
    void Start() {
        data = DataDeserializer.Deserialize();
        SetMoney();
        UpdateItems();
    }

    // Update is called once per frame
    void Update() {

    }

    void UpdateItems()
    {
        for (int i = 0; i < priceArray.Length; i++)
        {
            int index = i + 1;
            GameObject price = GameObject.Find("PriceText" + index);
            GameObject buyButton = GameObject.Find("Buy" + index);
            GameObject buyText = GameObject.Find("Text" + index);

            if (data.getAbilities().Contains(index)) {
                price.GetComponent<Text>().text = "owned";
                price.GetComponent<Text>().fontSize = 9;
            } else {
                price.GetComponent<Text>().text = "$" + priceArray[i];
                price.GetComponent<Text>().fontSize = 11;
            }

            if (data.getAbilities().Contains(index) && data.getSelectedAbility().Equals(index))
            {
                buyButton.GetComponent<Image>().color = new Color32(255,255,255,255);
                buyText.GetComponent<Text>().text = "equipped";
                buyButton.GetComponent<Button>().onClick.RemoveAllListeners();
            } else if (data.getAbilities().Contains(index))
            {
                buyButton.GetComponent<Image>().color = new Color32(57, 98, 255, 255);
                buyText.GetComponent<Text>().text = "equip";
                buyButton.GetComponent<Button>().onClick.RemoveAllListeners();
                buyButton.GetComponent<Button>().onClick.AddListener(() => OnClickEquip(index));
            } else if (priceArray[i] > data.getMoney())
            {
                buyButton.GetComponent<Image>().color = new Color32(212, 29, 7, 255);
                buyText.GetComponent<Text>().text = "insufficient";
                buyText.GetComponent<Text>().fontSize = 8;
                buyButton.GetComponent<Button>().onClick.RemoveAllListeners();
                buyButton.GetComponent<Button>().onClick.AddListener(() => OnClickBuy(index));
            } else
            {
                buyText.GetComponent<Text>().text = "buy";
                buyText.GetComponent<Text>().fontSize = 10;
                buyButton.GetComponent<Button>().onClick.RemoveAllListeners();
                buyButton.GetComponent<Button>().onClick.AddListener(() => OnClickBuy(index));
            }
        }
    }

    public void OnClickBuy(int index)
    {
        int price = priceArray[index - 1];
        if (data.getMoney() >= price)
        {
            data.setMoney(data.getMoney() - price);
            data.addAbility(index);
            DataSerializer.Serialize(data);
            Start();
        }
    }

    public void OnClickEquip(int index)
    {
        if (data.getSelectedAbility() != index && data.getAbilities().Contains(index))
        {
            data.setSelectedAbility(index);
            DataSerializer.Serialize(data);
            Start();
        }
    }

    public void OnSkinsClick()
    {
        SceneManager.LoadScene("Customization");
    }

    public void OnInformationClick(int index)
    {
        GameObject tab = GameObject.Find("Tab");
        GameObject informationTab = GameObject.Find("InformationTab");
        GameObject informationTabText = GameObject.Find("InformationText");

        informationTabText.GetComponent<Text>().text = GetAbilityByIndex(index);


        informationTab.transform.position = tab.transform.position;
    }

    public string GetAbilityByIndex(int index)
    {
        Debug.Log(index);
        switch (index)
        {
            case 1:
                return "The “Jump” ability makes you able to jump at all times!";
            case 2:
                return "The “Teleport” ability allows you to teleport 1 platform below you\nBeware this has a cooldown of 5 seconds!";
            case 3:
                return "The “Screen Pick-up” ability allows you to pick-up all the pick-ups on the screen.\nBeware this has a cooldown of 5 seconds!";
            case 4:
                return "The “Sand Speed” ability allows you to walk faster through sand at all times!";
            case 5:
                return "The “Line Pick-up” ability works as follows: when you pick up something, you automatically pick-up everything on the same line at all times!";
            default:
                return "";
        }
    }

    public void OnInformationDismiss()
    {
        GameObject informationTab = GameObject.Find("InformationTab");
        informationTab.transform.position = new Vector3(5000f, 5000f, 0);
    }

    public void OnUpgradesClick()
    {
        SceneManager.LoadScene("Upgrades");
    }

    public void OnBack()
    {
        SceneManager.LoadScene("Menu");
    }

    void SetMoney()
    {
        GameObject.FindGameObjectWithTag("EndGameMoney").GetComponent<Text>().text = data.getMoney().ToString();
    }
}
