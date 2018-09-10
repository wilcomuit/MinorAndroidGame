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
    public static Data defaultData = new Data(null, 0, 0, 0, 0);

    private Data(string playerName, int money, int highestFloors, int totalFloors, int finishedGames)
    {
        this.playerName = playerName;
        this.money = money;
        this.highestFloors = highestFloors;
        this.totalFloors = totalFloors;
        this.finishedGames = finishedGames;
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
}
