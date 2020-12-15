using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeGOOnLoad
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void LoadGOO() {
        GameObject backgroundMusic = (GameObject) GameObject.Instantiate(Resources.Load("Prefabs/InitializeOnLoad/BackgroundMusic", typeof(GameObject)));
        GameObject SFXsounds = (GameObject) GameObject.Instantiate(Resources.Load("Prefabs/InitializeOnLoad/SFXSounds", typeof(GameObject)));
        GameObject.Instantiate(Resources.Load("Prefabs/InitializeOnLoad/KeyManager", typeof(GameObject)));
        GameObject.Instantiate(Resources.Load("Prefabs/InitializeOnLoad/PlayerManager", typeof(GameObject)));
        GameObject.Instantiate(Resources.Load("Prefabs/InitializeOnLoad/MapManager", typeof(GameObject)));
        GameObject.Instantiate(Resources.Load("Prefabs/InitializeOnLoad/ItemManager", typeof(GameObject)));

        backgroundMusic.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("BackgroundMusicVolume", .5f);
        SFXsounds.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFXSoundsVolume", .5f);

    }

}
