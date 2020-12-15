using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class GameManager : MonoBehaviour
{

    GameObject gamePausedContainerPanel;

    [HideInInspector]
    public GameObject currentOpenMenuWindow;

    public static GameManager instance;

    void Awake()
    {
        if(instance != null)  {
            Destroy(gameObject);
            return;
        }
        instance = this;

        GameObject player = GameObject.FindWithTag("Player");
        if(player == null) {
            player = (GameObject) GameObject.Instantiate(Resources.Load("Prefabs/Characters/Player", typeof(GameObject)));
        }
        player.GetComponent<CharacterContainer>().characterData = PlayerManager.instance.currentPlayerData;

        GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>().Follow = player.transform;

        GameObject.Find("MapTitle").GetComponent<Text>().text = MapManager.instance.currentMap.mapName;

        gamePausedContainerPanel = GameObject.FindWithTag("GamePaused");
        if(gamePausedContainerPanel == null) {
            gamePausedContainerPanel = (GameObject) GameObject.Instantiate(Resources.Load("Prefabs/GamePausedMenu", typeof(GameObject)));
            gamePausedContainerPanel.transform.SetParent(GameObject.Find("Canvas").transform);
        }

        gamePausedContainerPanel.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;

            if(currentOpenMenuWindow != null) {
                currentOpenMenuWindow.SetActive(false);
                currentOpenMenuWindow = null;
                return;
            }

            GameObject GamePausedPanel = gamePausedContainerPanel.transform.Find("GamePausedPanel").gameObject;
            GamePausedPanel.SetActive(!GamePausedPanel.activeInHierarchy);
        }

    }
}
