using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using gc = GameController;

public class PlatformController : MonoBehaviour {

    public static int AMOUNT_OF_FLOORS = 97;

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
        gc.amountOfPlatforms += 1;
        gc.updateFloorCount();
        if (gc.sandProbability + gc.diamondProbability != 1000) {
            if (gc.emptyProbability != 0) {
                gc.goldProbability = gc.goldProbability - gc.probabilityMultiplier;
                gc.emptyProbability = gc.emptyProbability - gc.probabilityMultiplier;
            } else gc.goldProbability = gc.goldProbability - (gc.probabilityMultiplier *2);

            gc.sandProbability += gc.probabilityMultiplier;
            gc.diamondProbability += gc.probabilityMultiplier;
        }
        GameController.updateProbability();

        if (gc.gameType != -1 && gc.amountOfPlatforms == AMOUNT_OF_FLOORS)
        {
            GameObject chosen = gc.prefabEndInstance;
            Instantiate(
                    chosen,
                    new Vector3(0, gameObject.transform.position.y - 9f, 0),
                    gameObject.transform.rotation
                );

            Destroy(gameObject.transform.parent.gameObject);
        }
        else if (gc.gameType == -1 || gc.gameType != -1 && gc.amountOfPlatforms < AMOUNT_OF_FLOORS)
            {
            int platformIndex = GetPlatformIndex();
            GameObject chosen = gc.gameObjectList[platformIndex];
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
        int platformIndex = Random.Range(0, gc.gameObjectList.Count);
        if (gc.lastPlatformIndex == platformIndex)
        {
            return GetPlatformIndex();
        }
        gc.lastPlatformIndex = platformIndex;
        return platformIndex;
    }

    GameObject PickupRandomizer(GameObject platform)
    {
        foreach(Transform child in platform.transform)
        {
            if (child.gameObject.tag == "Pickup")
            {
                int random = Random.Range(0, 1000);
                if (random < gc.goldProbability)
                {
                    Instantiate(gc.pickupList[0], //gold
                    child.transform.position,
                    child.transform.rotation);
                } else if (random > gc.goldProbability && random < gc.goldProbability + gc.sandProbability)
                {
                    Instantiate(gc.pickupList[2], //sand
                       new Vector3(child.transform.position.x, child.transform.position.y - 0.2f, child.transform.position.z),
                       child.transform.rotation);
                } else if (random > gc.goldProbability + gc.sandProbability && random < gc.goldProbability + gc.sandProbability + gc.diamondProbability)
                {
                    Instantiate(gc.pickupList[1], //diamond
                    child.transform.position,
                    child.transform.rotation);
                }
            }
        }
        return platform;
    }

}
