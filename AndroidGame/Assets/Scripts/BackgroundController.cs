using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundController : MonoBehaviour {

    private BoxCollider2D backgroundCollider;
    private float backgroundSize;

    public GameObject mainCamera;

	void Start () {
        backgroundCollider = GetComponent<BoxCollider2D>();
        backgroundSize = backgroundCollider.size.y;

	}

    // Update is called once per frame
    void Update () {
        if (mainCamera.transform.position.y < (transform.position.y - backgroundSize))
        {
            RepositionBackground(mainCamera.transform.position.y);
        }
	}


    private void RepositionBackground(float cameraY)
    { 
        transform.position = new Vector3(transform.position.x, (transform.position.y-(backgroundSize*2)), transform.position.z);
    
    }
}
