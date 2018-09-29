using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour {

    public static float player_Speed = 0;
    public float playerSpeed = (float) 5;

    public static float obstacle_Speed = 0;
    public float obstacleSpeed = (float) 2.5;

    public static int challenge_Money = 250;
    public int challengeMoney = 250;

    public static int challenge_money_Percentage = 50;
    public int challengeMoneyPercentage = 50;




    void Awake () {
        player_Speed = playerSpeed;
        obstacle_Speed = obstacleSpeed;
        challenge_Money = challengeMoney;
        challenge_money_Percentage = challengeMoneyPercentage;
    }
	
	
}
