using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertisementController {

	public static void StartAdvertisements()
    {
        if (!Advertisement.isInitialized)
        {
            Advertisement.Initialize("2824729");
        }
    }
}
