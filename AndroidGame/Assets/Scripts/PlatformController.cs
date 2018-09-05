using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    void Start () {
    }
	
	void Update ()
    {
        Camera cam = Camera.main;
        if (gameObject != null && cam.transform.position.y + cam.orthographicSize < gameObject.transform.position.y)
        {
            CreatePlatformSequence();
        }
	}

    void CreatePlatformSequence()
    {
        int platformIndex = Random.Range(0, GameController.gameObjectList.Count);
        GameObject chosen = GameController.gameObjectList[platformIndex];
        chosen.transform.position = new Vector3(0, gameObject.transform.position.y - 9f, 0);
        chosen = PickupRandomizer(chosen);
        Instantiate(
                chosen,
                new Vector3(0, gameObject.transform.position.y - 9f, 0),
                gameObject.transform.rotation
            );
        Destroy(gameObject.transform.parent.gameObject);
    }


    GameObject PickupRandomizer(GameObject platform)
    {
        foreach(Transform child in platform.transform)
        {
            if (child.gameObject.tag == "Pickup")
            {
                int random = Random.Range(0, 100);
                if (random < 50)
                {
                    Instantiate(GameController.pickupList[0],
                    child.transform.position,
                    child.transform.rotation);
                }


                

            }
        }
        return platform;
    }
}
