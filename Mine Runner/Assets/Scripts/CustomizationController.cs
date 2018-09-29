using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomizationController : MonoBehaviour {

    private Data data;
    public int[] priceArray = new int[] { 0, 250, 500 };

    public GameObject equipped;
    public GameObject owned;
    public GameObject equip;

    void Start () {
        data = DataDeserializer.Deserialize();
        SetMoney();
        UpdateItems();
    }

    void UpdateItems()
    {
        for (int i = 0; i < priceArray.Length; i++)
        {
            int index = i + 1;
            GameObject parent = GameObject.Find("Item" + index);
            if (parent == null) continue;
            foreach (Transform inside in parent.transform)
            {
                if (inside.name == "Binnenground")
                {
                    foreach (Transform image in inside.transform)
                    {
                        if (image.name == "Price")
                        {
                            if (data.getSkins().Contains(index))
                            {
                                foreach (Transform text in image.transform)
                                {
                                    text.GetComponent<Text>().text = "owned";
                                }
                            }
                            else
                            {
                                foreach (Transform text in image.transform)
                                {
                                    text.GetComponent<Text>().text = "$" + priceArray[i];
                                }
                            }
                        }
                        else if (image.name == "Buy")
                        {
                            if (data.getSkins().Contains(index) && data.getSelectedSkin().Equals(index))
                            {
                                GameObject instantiatedObject = Instantiate(equipped, image.transform.position, image.transform.rotation) as GameObject;
                                instantiatedObject.transform.SetParent(inside, true);
                                instantiatedObject.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
                                instantiatedObject.transform.localScale = new Vector3(1, 1, 0);
                                Destroy(image.gameObject);
                            }
                            else if (data.getSkins().Contains(index))
                            {
                                GameObject instantiatedObject = Instantiate(equip, image.transform.position, image.transform.rotation) as GameObject;
                                instantiatedObject.transform.SetParent(inside, true);
                                instantiatedObject.transform.localScale = new Vector3(1, 1, 0);
                                instantiatedObject.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
                                instantiatedObject.GetComponent<Button>().onClick.AddListener(() => OnClickEquip(index));
                                Destroy(image.gameObject);
                            }
                            else if (priceArray[i] > data.getMoney())
                            {
                                image.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
                                image.Find("Text").GetComponent<Text>().text = "insufficient";
                                image.Find("Text").GetComponent<Text>().fontSize = 8;
                                image.GetComponent<Image>().color = new Color32(212, 29, 7, 255);
                                image.gameObject.GetComponent<Button>().onClick.AddListener(() => OnClickBuy(index));
                            } else {
                                image.Find("Text").GetComponent<Text>().text = "buy";
                                image.Find("Text").GetComponent<Text>().fontSize = 10;
                                image.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
                                image.gameObject.GetComponent<Button>().onClick.AddListener(() => OnClickBuy(index));
                            }
                        }
                    }
                }
            }
        }
        UpdateEquips();
    }

    void UpdateEquips()
    {
        for (int i = 0; i < priceArray.Length; i++)
        {
            int index = i + 1;
            
            GameObject parent = GameObject.Find("Item" + index);
            if (parent == null) continue;
            foreach (Transform inside in parent.transform)
            {
                int amountOfTries = 0;
                if (inside.name == "Binnenground")
                {
                    foreach (Transform image in inside.transform)
                    {
                        amountOfTries += 1;
                        if (amountOfTries > 10) break;
                        if (image.name.Contains("Equip") || image.name.Contains("Equipped"))
                        {
                            if (data.getSkins().Contains(index) && data.getSelectedSkin().Equals(index))
                            {
                                GameObject instantiatedObject = Instantiate(equipped, image.transform.position, image.transform.rotation) as GameObject;
                                instantiatedObject.transform.SetParent(inside, true);
                                instantiatedObject.transform.localScale = new Vector3(1, 1, 0);
                                Destroy(image.gameObject);
                            }
                            else if (data.getSkins().Contains(index))
                            {
                                GameObject instantiatedObject = Instantiate(equip, image.transform.position, image.transform.rotation) as GameObject;
                                instantiatedObject.transform.SetParent(inside, true);
                                instantiatedObject.transform.localScale = new Vector3(1, 1, 0);
                                instantiatedObject.GetComponent<Button>().onClick.AddListener(() => OnClickEquip(index));
                                Destroy(image.gameObject);
                            }
                        }
                    }
                }
            }
        }
        
    }
	
	void Update () {
		
	}

    public void OnClickUpgrades()
    {
        SceneManager.LoadScene("Upgrades");
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

    public void OnClickBuy( int index )
    {
        int price = priceArray[index-1];
        if (data.getMoney() >= price)
        {
            data.setMoney(data.getMoney() - price);
            data.addSkin(index);
            DataSerializer.Serialize(data);
            Start();
        }
    }

    public void OnClickEquip(int index)
    {
        if (data.getSelectedSkin() != index && data.getSkins().Contains(index))
        {
            data.setSelectedSkin(index);
            DataSerializer.Serialize(data);
            Start();
        }
    }
}
