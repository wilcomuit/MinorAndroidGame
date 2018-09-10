using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static float speed;
    public float startSpeed = 0.05f;
    public float obstacleSpeed = 0.025f;

	void Start () {
        speed = startSpeed;
	}

    void Update () {

        if (Input.GetKey("left"))
        {
            if(!MenuController.paused) transform.localScale = new Vector3(-0.176f, transform.localScale.y, transform.localScale.z);
            transform.Translate(-(speed/2), 0, 0);
        }
        if (Input.GetKey("right"))
        {
            if (!MenuController.paused) transform.localScale = new Vector3(0.176f, transform.localScale.y, transform.localScale.z);
            transform.Translate((speed/2), 0, 0);
        }

        foreach (Touch touch in Input.touches)
        {
            //links
            if (touch.position.x < Screen.width / 2)
            {
                transform.localScale = new Vector3(-0.176f, transform.localScale.y, transform.localScale.z);
                transform.Translate(-speed, 0, 0);
            }
            //rechts
            else if (touch.position.x > Screen.width / 2)
            {
                transform.localScale = new Vector3(0.176f, transform.localScale.y, transform.localScale.z);
                transform.Translate(speed, 0, 0);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            Destroy(other.gameObject);
            GameController.score += 1;
            GameController.updateScore();
        } else if (other.gameObject.tag == "Obstacle")
        {
            speed = obstacleSpeed;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            speed = startSpeed;
        }
    }
}
