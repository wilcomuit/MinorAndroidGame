using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsController : MonoBehaviour {

    Data data;

    public RuntimeAnimatorController animationSkin1;
    public RuntimeAnimatorController animationSkin2;
    public static List<RuntimeAnimatorController> animationSkinList = new List<RuntimeAnimatorController>();

    void Start () {
        data = DataDeserializer.Deserialize();
        animationSkinList.Add(animationSkin1);
        animationSkinList.Add(animationSkin2);
        RuntimeAnimatorController controller = animationSkinList[DataDeserializer.Deserialize().getSelectedSkin() - 1];
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().runtimeAnimatorController = controller as RuntimeAnimatorController;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
