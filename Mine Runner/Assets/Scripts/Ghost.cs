using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ghost
{
    private List<float> ghostPlayerX;
    private List<float> ghostPlayerY;
    private List<bool> ghostPlayerFlip;
    private List<float> ghostPlayerSpeed;
    private int selectedSkin;
    public static Ghost defaultData = new Ghost(new List<float>(), new List<float>(), new List<bool>(), new List<float>(), 1);

    public Ghost(List<float> ghostPlayerX, List<float> ghostPlayerY, List<bool> ghostPlayerFlip, List<float> ghostPlayerSpeed, int selectedSkin)
    {
        this.ghostPlayerX = (ghostPlayerX == null) ? new List<float>() : ghostPlayerX;
        this.ghostPlayerY = (ghostPlayerY == null) ? new List<float>() : ghostPlayerY;
        this.ghostPlayerFlip = (ghostPlayerFlip == null) ? new List<bool>() : ghostPlayerFlip;
        this.ghostPlayerSpeed = (ghostPlayerSpeed == null) ? new List<float>() : ghostPlayerSpeed;
        this.selectedSkin = (selectedSkin == 0) ? 1 : selectedSkin;

    }

    public List<float> getGhostPlayerX()
    {
        this.ghostPlayerX = (this.ghostPlayerX == null) ? new List<float>() : this.ghostPlayerX;
        return this.ghostPlayerX;
    }
    public void setGhostPlayerX(List<float> ghostPlayerX)
    {
        this.ghostPlayerX = (ghostPlayerX == null) ? new List<float>() : ghostPlayerX;
        this.ghostPlayerX = ghostPlayerX;
    }

    public List<float> getGhostPlayerY()
    {
        this.ghostPlayerY = (this.ghostPlayerY == null) ? new List<float>() : this.ghostPlayerY;
        return this.ghostPlayerY;
    }
    public void setGhostPlayerY(List<float> ghostPlayerY)
    {
        this.ghostPlayerY = (ghostPlayerY == null) ? new List<float>() : ghostPlayerY;
    }
    public List<bool> getGhostPlayerFlip()
    {
        this.ghostPlayerFlip = (this.ghostPlayerFlip == null) ? new List<bool>() : this.ghostPlayerFlip;
        return this.ghostPlayerFlip;
    }
    public void setGhostPlayerFlip(List<bool> ghostPlayerY)
    {
        this.ghostPlayerFlip = (ghostPlayerFlip == null) ? new List<bool>() : ghostPlayerFlip;
    }
    public List<float> getGhostPlayerSpeed()
    {
        this.ghostPlayerSpeed = (this.ghostPlayerSpeed == null) ? new List<float>() : this.ghostPlayerSpeed;
        return this.ghostPlayerSpeed;
    }
    public void setGhostPlayerSpeed(List<float> ghostPlayerSpeed)
    {
        this.ghostPlayerSpeed = (ghostPlayerSpeed == null) ? new List<float>() : ghostPlayerSpeed;
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
}
