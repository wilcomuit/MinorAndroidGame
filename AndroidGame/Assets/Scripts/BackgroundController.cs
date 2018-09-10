using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundController : MonoBehaviour {

    private BoxCollider2D backgroundCollider;
    private float backgroundSize;

	void Start () {
        backgroundCollider = GetComponent<BoxCollider2D>();
        backgroundSize = backgroundCollider.size.y;

	}

    // Update is called once per frame
    void Update () {
        if (Camera.main.transform.position.y < (transform.position.y - backgroundSize))
        {
            RepositionBackground(Camera.main.transform.position.y);
        }
	}


    private void RepositionBackground(float cameraY)
    {
        if (gameObject.tag == "wallBackground") {
            transform.position = new Vector3(transform.position.x, (transform.position.y - (backgroundSize * 2)), transform.position.z);
        } else {
            int random = Random.Range(0, GameController.backgroundList.Count);
            Instantiate(GameController.backgroundList[random],
                         new Vector3(transform.position.x, (transform.position.y - (backgroundSize * 2)), transform.position.z),
                        transform.rotation);

            Destroy(gameObject);
        }
    }
}
