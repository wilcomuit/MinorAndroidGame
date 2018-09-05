using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private float height;
    private float playerHeight;
    public GameObject player;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        height = GetComponent<Renderer>().bounds.size.y;
        rb2d.velocity = new Vector2(0, -2.3f);
    }

    void Update()
    {
        if (gameObject.transform.position.y - (height/2) < player.transform.position.y)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
