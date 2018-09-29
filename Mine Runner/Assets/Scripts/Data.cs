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
    private int moneyMultiplier;
    private int speedMultiplier;
    private int selectedSkin;
    private int volume;
    private int selectedAbility;
    private List<int> skins;
    private List<int> abilities;
    private bool showGhost;
    private List<float> highscores;
    public static List<int> defaultSkinList = new List<int>();
    public static List<float> defaultHighscores = new List<float>();
    private float waterSpeed;
    public static Data defaultData = new Data(null, 0, 0, 0, 0, null, 1, 1, 1, 100, true, null, null, 0, 2.3f);
    private Data(string playerName, int money, int highestFloors, int totalFloors, int finishedGames, List<int> skins, int moneyMultiplier, int speedMultiplier, int selectedSkin, int volume, bool showGhost, List<float> highscores, List<int> abilities, int selectedAbility, float waterSpeed)
    {
        this.playerName = (playerName == null) ? "" : playerName;
        this.money = (money == 0) ? 0 : money;
        this.highestFloors = (highestFloors == 0) ? 0 : highestFloors;
        this.totalFloors = (totalFloors == 0) ? 0 : totalFloors;
        this.finishedGames = (finishedGames == 0) ? 0 : finishedGames;
        this.skins = (skins == null) ? defaultSkinList : skins;
        this.abilities = (abilities == null) ? new List<int>() : abilities;
        this.selectedAbility = (selectedAbility == 0) ? 0 : selectedAbility;
        this.moneyMultiplier = (moneyMultiplier == 0) ? 1 : moneyMultiplier;
        this.speedMultiplier = (speedMultiplier == 0) ? 1 : speedMultiplier;
        this.selectedSkin = (selectedSkin == 0) ? 1 : selectedSkin;
        this.volume = volume;
        this.showGhost = showGhost;
        this.highscores = (highscores == null) ? defaultHighscores : highscores;
        this.waterSpeed = waterSpeed;
    }

    public string getPlayerName()
    {
        this.playerName = (this.playerName == null) ? "" : this.playerName;
        return this.playerName;
    }
    public void setPlayerName(string playerName)
    {
        this.playerName = (playerName == null) ? "" : playerName;
    }
    public int getMoney()
    {
        this.money = (this.money == 0) ? 0 : this.money;
        return this.money;
    }
    public void setMoney(int money)
    {
        this.money = (money == 0) ? 0 : money;
    }
    public int getHighestFloors()
    {
        this.highestFloors = (this.highestFloors == 0) ? 0 : this.highestFloors;
        return this.highestFloors;
    }
    public void setHighestFloors(int highestFloors)
    {
        this.highestFloors = (highestFloors == 0) ? 0 : highestFloors;
    }
    public int getTotalFloors()
    {
        this.totalFloors = (this.totalFloors == 0) ? 0 : this.totalFloors;
        return this.totalFloors;
    }
    public void setTotalFloors(int totalFloors)
    {
        this.totalFloors = (totalFloors == 0) ? 0 : totalFloors;
    }
    public int getFinishedGames()
    {
        this.finishedGames = (this.finishedGames == 0) ? 0 : this.finishedGames;
        return this.finishedGames;
    }
    public void setFinishedGames(int finishedGames)
    {
        this.finishedGames = (finishedGames == 0) ? 0 : finishedGames;
    }
    public List<int> getSkins()
    {
        this.skins = (this.skins == null) ? defaultSkinList : this.skins;
        return this.skins;
    }
    public void setSkins(List<int> skins)
    {
        this.skins = (skins == null) ? defaultSkinList : skins;
    }
    public void addSkin(int skin)
    {
        this.skins.Add(skin);
    }
    public int getMoneyMultiplier()
    {
        this.moneyMultiplier = (this.moneyMultiplier == 0) ? 1 : this.moneyMultiplier;
        return this.moneyMultiplier;
    }
    public void setMoneyMultiplier(int moneyMultiplier)
    {
        this.moneyMultiplier = (moneyMultiplier == 0) ? 1 : moneyMultiplier;
    }

    public int getSpeedMultiplier()
    {
        return this.speedMultiplier;
    }
    public void setSpeedMultiplier(int speedMultiplier)
    {
        this.speedMultiplier = (speedMultiplier == 0) ? 1 : speedMultiplier;
    }
    public int getSelectedSkin()
    {
        this.selectedSkin = (this.selectedSkin == 0) ? 1 : this.selectedSkin;
        return this.selectedSkin;
    }
    public void setSelectedSkin(int selectedSkin)
    {
        this.selectedSkin = (selectedSkin == 0) ? 1 : selectedSkin;
    }
    public int getVolume()
    {
        return this.volume;
    }
    public void setVolume(int volume)
    {
        this.volume = volume;
    }
    public bool getShowGhost()
    {
        return this.showGhost;
    }
    public void setShowGhost(bool showGhost)
    {
        this.showGhost = showGhost;
    }

    public List<float> getHighscores()
    {
        this.highscores = (this.highscores == null) ? defaultHighscores : this.highscores;
        return this.highscores;
    }
    public void setHighscores(List<float> skins)
    {
        this.highscores = (highscores == null) ? defaultHighscores : highscores;
    }

    public List<int> getAbilities()
    {
        this.abilities = (this.abilities == null) ? new List<int>() : this.abilities;
        return this.abilities;
    }
    public void setAbilities(List<int> abilities)
    {
        this.abilities = (abilities == null) ? new List<int>() : abilities;
    }
    public void addAbility(int ability)
    {
        this.abilities.Add(ability);
    }

    public int getSelectedAbility()
    {
        this.selectedAbility = (this.selectedAbility == 0) ? 0 : this.selectedAbility;
        return this.selectedAbility;
    }
    public void setSelectedAbility(int selectedAbility)
    {
        this.selectedAbility = (selectedAbility == 0) ? 0 : selectedAbility;
    }

    public float getWaterSpeed()
    {
        this.waterSpeed = (this.waterSpeed == 0) ? 2.3f : this.waterSpeed;
        return this.waterSpeed;
    }
    public void setWaterSpeed(float waterSpeed)
    {
        this.waterSpeed = (waterSpeed == 0) ? 2.3f : waterSpeed;
    }
}
        