using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    public GameObject playerUI;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => Clicked());
    }

    void Clicked() {
        PlayerManager.instance.UpdatePlayer(playerUI.GetComponent<CharacterContainer>().characterData);
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }
}
