using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public CharacterData currentPlayerData { get; private set; }

    public static PlayerManager instance;

    void Awake()
    {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        currentPlayerData = (CharacterData) GameObject.Instantiate(Resources.Load("ScriptableObject/Characters/YoungBuck", typeof(CharacterData)));

    }

    public void UpdatePlayer(CharacterData newPlayer) {
        currentPlayerData = newPlayer;
    }
}
