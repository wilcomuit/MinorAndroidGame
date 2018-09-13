using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using g = Globals;

public class PlayerController : MonoBehaviour {

    public static float speed;
    Animator animator;
    SpriteRenderer spriteRenderer;
    bool isFacingRight = true;


    public static int moneyMultiplier;

	void Start () {
        Data data = DataDeserializer.Deserialize();

        speed = g.player_Speed;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        moneyMultiplier = data.getMoneyMultiplier();
	}

    void Update () {

        float horizontal = Input.GetAxis("Horizontal");

        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x < Screen.width / 2)
            {
                horizontal = -1.5f;
            }
            else if (touch.position.x > Screen.width / 2)
            {
                horizontal = 1.5f;
            }
        }

        transform.Translate(horizontal * speed, 0, 0);
        if (!MenuController.paused)
        {
            animator.SetFloat("speed", Math.Abs(horizontal));

            if (horizontal < 0 && isFacingRight || horizontal > 0 && !isFacingRight)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
                isFacingRight = !isFacingRight;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            Destroy(other.gameObject);
            GameController.score += (1*moneyMultiplier);
            GameController.updateScore();
        } else if (other.gameObject.tag == "Pickup2")
        {
            Destroy(other.gameObject);
            GameController.score += (25*moneyMultiplier);
            GameController.updateScore();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            speed = g.obstacle_Speed;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            speed = g.player_Speed;
        }
    }
}
