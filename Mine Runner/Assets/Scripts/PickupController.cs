using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Camera cam = Camera.main;
        if (gameObject != null && cam.transform.position.y + cam.orthographicSize < gameObject.transform.position.y)
        {
            Destroy(gameObject);
        }
    }

    

}
