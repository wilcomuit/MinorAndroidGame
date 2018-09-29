using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    public float obstacleSpeed = 0.025f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //PlayerController.speed = obstacleSpeed;
    }

    void OnTriggerExit2D(Collider2D other)
    {

    }

}
