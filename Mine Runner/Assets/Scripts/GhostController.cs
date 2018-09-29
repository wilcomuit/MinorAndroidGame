using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {

    private List<float> positionsX;
    private List<float> positionsY;
    private List<bool> positionsFlip;
    private List<float> positionsSpeed;
    int index = 0;

    public RuntimeAnimatorController animationSkin1;
    public RuntimeAnimatorController animationSkin2;
    public RuntimeAnimatorController animationSkin3;
    public RuntimeAnimatorController animationSkin4;
    public RuntimeAnimatorController animationSkin5;
    public RuntimeAnimatorController animationSkin6;
    public static List<RuntimeAnimatorController> animationSkinList = new List<RuntimeAnimatorController>();

    private Animator animator;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Awake () {
        Ghost ghost = GhostDeserializer.Deserialize("Challenge" + GameController.gameType);
        Data data = DataDeserializer.Deserialize();
        if (data.getShowGhost())
        {
            positionsX = ghost.getGhostPlayerX();
            positionsY = ghost.getGhostPlayerY();
            positionsFlip = ghost.getGhostPlayerFlip();
            positionsSpeed = ghost.getGhostPlayerSpeed();
        }
        else
        {
            positionsX = new List<float>();
            positionsY = new List<float>();
            positionsFlip = new List<bool>();
            positionsSpeed = new List<float>();
        }
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        animationSkinList.Add(animationSkin1);
        animationSkinList.Add(animationSkin2);
        animationSkinList.Add(animationSkin3);
        animationSkinList.Add(animationSkin4);
        animationSkinList.Add(animationSkin5);
        animationSkinList.Add(animationSkin6);
        RuntimeAnimatorController controller = animationSkinList[ghost.getSelectedSkin() - 1];
        GetComponent<Animator>().runtimeAnimatorController = controller as RuntimeAnimatorController;
    }

    // Update is called once per frame
    void Update () {
        if (positionsX != null  && positionsY != null && positionsX.Count > index && positionsY.Count > index && !GameController.paused)
        {
            transform.position = new Vector3(positionsX[index],positionsY[index],0);
            animator.SetFloat("speed", Math.Abs(positionsSpeed[index]));
            spriteRenderer.flipX = !positionsFlip[index];
            index++;
        }
	}
}
