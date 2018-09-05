using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

	void Start () {
		
	}
	
	void Update () {

        if (Input.GetKey("left"))
        {
            transform.Translate(-0.025f, 0, 0);
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(0.025f, 0, 0);
        }

        foreach (Touch touch in Input.touches)
        {
            //links
            if (touch.position.x < Screen.width / 2)
            {
                transform.Translate(-0.05f, 0, 0);
            }
            //rechts
            else if (touch.position.x > Screen.width / 2)
            {
                transform.Translate(0.05f, 0, 0);
            }
        }

    }
}
