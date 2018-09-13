using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackgroundController : MonoBehaviour {

    private BoxCollider2D backgroundCollider;
    private Rigidbody2D rigid;
    private float backgroundSize;

    // Use this for initialization
    void Start () {
        backgroundCollider = GetComponent<BoxCollider2D>();
        backgroundSize = backgroundCollider.size.y * gameObject.transform.localScale.y;
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(0, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        if ((transform.position.y - backgroundSize) > (Camera.main.transform.position.y))
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        transform.position = new Vector3(transform.position.x, (transform.position.y - (backgroundSize * 2)), transform.position.z);   
    }
}
