using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsController : MonoBehaviour {

    public RuntimeAnimatorController animationSkin1;
    public RuntimeAnimatorController animationSkin2;
    public RuntimeAnimatorController animationSkin3;
    public RuntimeAnimatorController animationSkin4;
    public RuntimeAnimatorController animationSkin5;
    public RuntimeAnimatorController animationSkin6;
    public static List<RuntimeAnimatorController> animationSkinList = new List<RuntimeAnimatorController>();

    void Start () {
        animationSkinList.Add(animationSkin1);
        animationSkinList.Add(animationSkin2);
        animationSkinList.Add(animationSkin3);
        animationSkinList.Add(animationSkin4);
        animationSkinList.Add(animationSkin5);
        animationSkinList.Add(animationSkin6);
        RuntimeAnimatorController controller = animationSkinList[DataDeserializer.Deserialize().getSelectedSkin() - 1];
        GetComponent<Animator>().runtimeAnimatorController = controller as RuntimeAnimatorController;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
