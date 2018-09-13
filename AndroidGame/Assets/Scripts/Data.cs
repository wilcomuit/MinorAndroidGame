using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data {

    private string playerName;
    private int money;
    private int highestFloors;
    private int totalFloors;
    private int finishedGames;
    private List<int> skins;
    private int moneyMultiplier;
    private int selectedSkin;
    public static List<int> defaultSkinList = new List<int>();
    public static Data defaultData = new Data(null, 0, 0, 0, 0, defaultSkinList, 1, 1);

    private Data(string playerName, int money, int highestFloors, int totalFloors, int finishedGames, List<int> skins, int moneyMultiplier, int selectedSkin)
    {
        this.playerName = playerName;
        this.money = money;
        this.highestFloors = highestFloors;
        this.totalFloors = totalFloors;
        this.finishedGames = finishedGames;
        this.skins = skins;
        this.moneyMultiplier = moneyMultiplier;
        this.selectedSkin = selectedSkin;
    }

    public string getPlayerName()
    {
        return this.playerName;
    }
    public void setPlayerName(string playerName)
    {
        this.playerName = playerName;
    }
    public int getMoney()
    {
        return this.money;
    }
    public void setMoney(int money)
    {
        this.money = money;
    }
    public int getHighestFloors()
    {
        return this.highestFloors;
    }
    public void setHighestFloors(int highestFloors)
    {
        this.highestFloors = highestFloors;
    }
    public int getTotalFloors()
    {
        return this.totalFloors;
    }
    public void setTotalFloors(int totalFloors)
    {
        this.totalFloors = totalFloors;
    }
    public int getFinishedGames()
    {
        return this.finishedGames;
    }
    public void setFinishedGames(int finishedGames)
    {
        this.finishedGames = finishedGames;
    }
    public List<int> getSkins()
    {
        return this.skins;
    }
    public void setSkins(List<int> skins)
    {
        this.skins = skins;
    }
    public void addSkin(int skin)
    {
        this.skins.Add(skin);
    }
    public int getMoneyMultiplier()
    {
        return this.moneyMultiplier;
    }
    public void setMoneyMultiplier(int moneyMultiplier)
    {
        this.moneyMultiplier = moneyMultiplier;
    }
    public int getSelectedSkin()
    {
        return this.selectedSkin;
    }
    public void setSelectedSkin(int selectedSkin)
    {
        this.selectedSkin = selectedSkin;
    }
}
