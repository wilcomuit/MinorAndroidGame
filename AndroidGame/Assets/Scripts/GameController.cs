using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;
    public GameObject prefab7;
    public GameObject prefab8;
    public GameObject prefab9;
    public GameObject prefab10;
    public static List<GameObject> gameObjectList = new List<GameObject>();

    public GameObject pickupObject1;
    public static List<GameObject> pickupList = new List<GameObject>();

    void Awake()
    {
        gameObjectList.Add(prefab1);
        gameObjectList.Add(prefab2);
        gameObjectList.Add(prefab3);
        gameObjectList.Add(prefab4);
        gameObjectList.Add(prefab5);
        gameObjectList.Add(prefab6);
        gameObjectList.Add(prefab7);
        gameObjectList.Add(prefab8);
        gameObjectList.Add(prefab9);
        gameObjectList.Add(prefab10);

        pickupList.Add(pickupObject1);
    }


	void Start () {
		
	}
	
	void Update () {
		
	}
}
