using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour {

	void Start () {
		
	}

    void Update()
    {
        
    }
    void OnMouseDown()
    {
        // this object was clicked - do something
        SceneManager.LoadScene("Game");
    }
}
