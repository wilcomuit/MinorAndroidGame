using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour {

    public static GameObject gObject;

    void Start() {
        
        if (gameObject.tag == "Indestructible" && gObject == null)
        {
            gObject = gameObject;
            DontDestroyOnLoad(gObject);
            ChangingScene();
        }
        
    }

    public static void ChangeVolume()
    {
        Data data = DataDeserializer.Deserialize();
        if (gObject)
        {
            foreach (AudioSource source in gObject.GetComponents<AudioSource>())
            {
                source.volume = ((float)data.getVolume() / 100);
            }
        }
    }

    public static void ChangingScene()
    {
        ChangeVolume();
        if (SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "Challenge100")
        {
            if (gObject && gObject.GetComponents<AudioSource>().Length >= 3)
            {
                if (!gObject.GetComponents<AudioSource>()[0].isPlaying && !gObject.GetComponents<AudioSource>()[1].isPlaying)
                {
                    gObject.GetComponents<AudioSource>()[2].Stop();
                    gObject.GetComponents<AudioSource>()[0].Play();
                    gObject.GetComponents<AudioSource>()[1].PlayDelayed(gObject.GetComponents<AudioSource>()[0].clip.length);
                }
            }
            
        }
        else
        {
            if (gObject && gObject.GetComponents<AudioSource>().Length >= 3)
            {
                if (!gObject.GetComponents<AudioSource>()[2].isPlaying)
                {
                    gObject.GetComponents<AudioSource>()[0].Stop();
                    gObject.GetComponents<AudioSource>()[1].Stop();
                    gObject.GetComponents<AudioSource>()[2].Play();
                }
            }
        }
    }
}
