using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour {

    public static float player_Speed = 0;
    public float playerSpeed = (float) 5;

    public static float obstacle_Speed = 0;
    public float obstacleSpeed = (float) 2.5;








    void Awake () {
        player_Speed = playerSpeed;
        obstacle_Speed = obstacleSpeed;
	}
	
	
}
