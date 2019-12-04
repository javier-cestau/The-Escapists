using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]

public struct MapLevel {
    public string difficulty;
    public string mapName;
    public string thumbnail;
    public int inmateAmount;
    public int policeAmount;
}

public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    public List<MapLevel> maps = new List<MapLevel>();

    public MapLevel currentMap;
    public int currentMapIndex { get; private set; }

    void Awake()
    {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        currentMapIndex = 0;

        // Maps could be Scriptable Object, but It's just to show how to handle JSON files
        string filePath = Path.Combine(Application.streamingAssetsPath, "maps.json");
        if(File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            MapLevelArray loadedData = JsonUtility.FromJson<MapLevelArray>(dataAsJson);

            foreach (MapLevel map in loadedData.maps)
            {
                maps.Add(map);
            }

            currentMap = maps[currentMapIndex];

            // Debug.Log(loadedData);
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }

    [System.Serializable]
    struct MapLevelArray {
        public MapLevel[] maps;

        public MapLevelArray(MapLevel[] _maps) {
            this.maps = _maps;
        }
    }



    public void ChangeMap(bool next) {
        if(next) {
            if((currentMapIndex + 1) < maps.Count) {
                currentMapIndex++;
                currentMap = maps[currentMapIndex];
            }
        } else {
            if((currentMapIndex - 1) >= 0) {
                currentMapIndex--;
                currentMap = maps[currentMapIndex];
            }
        }
    }

}
