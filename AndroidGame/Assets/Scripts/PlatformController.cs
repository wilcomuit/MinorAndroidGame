using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    public static int AMOUNT_OF_FLOORS = 97;
    public int goldProbability = 500;
    public int sandProbability = 150;
    public int diamondProbability = 0;
    public int emptyProbability = 350;
    public int probabilityMultiplier = 1;

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
        GameController.amountOfPlatforms += 1;
        GameController.updateFloorCount();
        if (sandProbability + diamondProbability != 1000) {
            if (emptyProbability != 0) {
                goldProbability = goldProbability - probabilityMultiplier;
                emptyProbability = emptyProbability - probabilityMultiplier;
            } else goldProbability = goldProbability - (probabilityMultiplier*2);

            sandProbability += probabilityMultiplier;
            diamondProbability += probabilityMultiplier;
        }

        if (GameController.gameType != -1 && GameController.amountOfPlatforms == AMOUNT_OF_FLOORS)
        {
            GameObject chosen = GameController.prefabEndInstance;
            Instantiate(
                    chosen,
                    new Vector3(0, gameObject.transform.position.y - 9f, 0),
                    gameObject.transform.rotation
                );

            Destroy(gameObject.transform.parent.gameObject);
        }
        else if (GameController.gameType == -1 || GameController.gameType != -1 && GameController.amountOfPlatforms < AMOUNT_OF_FLOORS)
            {
            int platformIndex = GetPlatformIndex();
            GameObject chosen = GameController.gameObjectList[platformIndex];
            chosen.transform.position = new Vector3(0, gameObject.transform.position.y - 9f, 0);
            chosen = PickupRandomizer(chosen);
            Instantiate(
                    chosen,
                    new Vector3(0, gameObject.transform.position.y - 9f, 0),
                    gameObject.transform.rotation
                );
            Destroy(gameObject.transform.parent.gameObject);
        } else {
            Destroy(gameObject.transform.parent.gameObject);
        }
        
    }

    int GetPlatformIndex()
    {
        int platformIndex = Random.Range(0, GameController.gameObjectList.Count);
        if (GameController.lastPlatformIndex == platformIndex)
        {
            return GetPlatformIndex();
        }
        GameController.lastPlatformIndex = platformIndex;
        return platformIndex;
    }

    GameObject PickupRandomizer(GameObject platform)
    {
        foreach(Transform child in platform.transform)
        {
            if (child.gameObject.tag == "Pickup")
            {
                int random = Random.Range(0, 1000);
                if (random < goldProbability)
                {
                    Instantiate(GameController.pickupList[0], //gold
                    child.transform.position,
                    child.transform.rotation);
                } else if (random > goldProbability && random < goldProbability + sandProbability)
                {
                    Instantiate(GameController.pickupList[1], //sand
                       new Vector3(child.transform.position.x, child.transform.position.y - 0.12f, child.transform.position.z),
                       child.transform.rotation);
                } else if (random > goldProbability + sandProbability && random < goldProbability + sandProbability + diamondProbability)
                {
                    Instantiate(GameController.pickupList[0], //diamond
                    child.transform.position,
                    child.transform.rotation);
                }
            }
        }
        return platform;
    }

}
