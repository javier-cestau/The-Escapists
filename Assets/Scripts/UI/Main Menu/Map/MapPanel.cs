using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPanel : MonoBehaviour
{

    MapLevel currentMap = new MapLevel();

    Text mapName;
    Text difficulty;
    Image thumbnail;
    void Awake()
    {
        mapName = transform.Find("MapName").GetComponent<Text>();
        difficulty = transform.Find("Difficulty").GetComponent<Text>();
        thumbnail = transform.Find("Thumbnail").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentMap.mapName != MapManager.instance.currentMap.mapName) {
            currentMap = MapManager.instance.currentMap;
            mapName.text = currentMap.mapName;
            difficulty.text = currentMap.difficulty;
            thumbnail.sprite = Resources.Load<Sprite>("Images/Maps/" + currentMap.thumbnail) ;

        }
    }
}
