using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using System.IO;

public class GridNPC : MonoBehaviour
{

    public GameObject inmate;
    public GameObject police;
    public GameObject borderSelector;

    public RuntimeAnimatorController[] BInmateHeads;
    public RuntimeAnimatorController[] WInmateHeads;

    [Space]
    public RuntimeAnimatorController BInmateBody;
    public RuntimeAnimatorController WInmateBody;

    struct RandonName {
        public string[] names;

        public RandonName(string[] _names)  {
            this.names = _names;
        }
    }

    string[] randomNames;
    const string WHITE_INMATE = "W", BLACK_INMATE = "B";

    void OnEnable() {

        string filePath = Path.Combine(Application.streamingAssetsPath, "names.json");
        NPCManager.listInmateCharactersData.Clear();
        NPCManager.listPoliceCharactersData.Clear();

        if(randomNames != null) {
            GenerateNPCs();
            return;
        }

        if(File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            RandonName loadedData = JsonUtility.FromJson<RandonName>(dataAsJson);
            randomNames = loadedData.names;
            GenerateNPCs();

        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }

    public void RandomNPC() {
        if(NPCManager.listInmateCharactersData.Count > 0 ) {
            foreach (CharacterData data in NPCManager.listInmateCharactersData)
            {
                SetRandomInmate(data);
            }

            foreach (CharacterData data in NPCManager.listPoliceCharactersData)
            {
                SetRandomPolice(data);
            }
            return;
        }
    }

    void GenerateNPCs() {
        int countInmate = 0;
        int countPolice = 0;

        // Reuse existing GO on NPCGrid and not create more GO
        // (Pooling Technique)
        foreach (Transform child in transform)
        {
            CharacterContainer characterContainer = child.GetComponent<CharacterContainer>();
            if(Regex.Match(child.name, "Inmate").Success) {
                if(countInmate < MapManager.instance.currentMap.inmateAmount) {
                    SetRandomInmate(characterContainer.characterData);
                    child.gameObject.SetActive(true);
                    NPCManager.listInmateCharactersData.Add(characterContainer.characterData);
                    countInmate++;
                } else {
                    child.gameObject.SetActive(false);
                }
            }
            if (Regex.Match(child.name, "Police").Success ) {
                if(countPolice < MapManager.instance.currentMap.policeAmount) {
                    SetRandomPolice(characterContainer.characterData);
                    countPolice++;
                    NPCManager.listPoliceCharactersData.Add(characterContainer.characterData);
                    child.gameObject.SetActive(true);
                } else {
                    child.gameObject.SetActive(false);
                }
            }

        }

        while(countInmate < MapManager.instance.currentMap.inmateAmount)
        {
            GameObject character = (GameObject) Instantiate(inmate, Vector3.zero, Quaternion.identity, transform);
            Instantiate(borderSelector, new Vector2(0,-.02f), Quaternion.identity, character.transform);
            character.transform.SetSiblingIndex(countInmate);
            character.AddComponent<SelectorNPC>();
            CharacterContainer characterContainer = character.GetComponent<CharacterContainer>();
            characterContainer.characterData = Instantiate(characterContainer.characterData) as CharacterData; // duplicate for a uniq ScriptableObject instance
            SetRandomInmate(characterContainer.characterData);
            NPCManager.listInmateCharactersData.Add(characterContainer.characterData);
            countInmate++;
        }

        while(countPolice < MapManager.instance.currentMap.policeAmount)
        {
            GameObject character = (GameObject) Instantiate(police, Vector3.zero, Quaternion.identity, transform);
            Instantiate(borderSelector, new Vector2(0,-.02f), Quaternion.identity, character.transform);
            character.AddComponent<SelectorNPC>();
            CharacterContainer characterContainer = character.GetComponent<CharacterContainer>();
            characterContainer.characterData = Instantiate(characterContainer.characterData) as CharacterData; // duplicate for a uniq ScriptableObject instance
            SetRandomPolice(characterContainer.characterData);
            NPCManager.listPoliceCharactersData.Add(characterContainer.characterData);
            countPolice++;
        }
    }

    void SetRandomInmate(CharacterData characterData) {
        string type = Random.value  >= .5f ? "W" : "B";
        RuntimeAnimatorController[] heads = (RuntimeAnimatorController[]) this.GetType().GetField(type + "InmateHeads").GetValue(this);
        int index = Random.Range(0, heads.Length);
        characterData.name = randomNames[Random.Range(0, randomNames.Length)];
        characterData.characterName = characterData.name;
        characterData.head = heads[index];
        characterData.body = (RuntimeAnimatorController) this.GetType().GetField(type + "InmateBody").GetValue(this);;
    }

    void SetRandomPolice(CharacterData characterData) {
        characterData.name = "Oficcer " + randomNames[Random.Range(0, randomNames.Length)];
        characterData.characterName = characterData.name;
    }
}
