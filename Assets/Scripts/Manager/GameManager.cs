using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        if(GameObject.FindWithTag("Player") == null) {
            GameObject player = (GameObject) GameObject.Instantiate(Resources.Load("Prefabs/Characters/Player", typeof(GameObject)));
            player.GetComponent<CharacterContainer>().characterData = PlayerManager.instance.currentPlayerData;
        }
    }
}
