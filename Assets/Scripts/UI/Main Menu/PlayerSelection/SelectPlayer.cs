using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlayer : MonoBehaviour
{
    public List<CharacterData> listCharacter = new List<CharacterData>();

    [HideInInspector]
    public CharacterData currentCharacter;

    [HideInInspector]
    public int currentCharacterIndex = 0;

    CharacterContainer characterContainer;
    public Button continueButton;

    InputField nameInput;

    // Start is called before the first frame update
    void Awake()
    {
        characterContainer = GetComponentInChildren<CharacterContainer>();
        nameInput = GetComponentInChildren<InputField>();

        currentCharacterIndex = 0;
        currentCharacter = listCharacter[0];
        characterContainer.characterData = currentCharacter;
        nameInput.text = currentCharacter.name;

    }

    public void ChangeCharacter(bool next)
    {
        if(next) {
            if((currentCharacterIndex + 1) < listCharacter.Count) {
                currentCharacterIndex++;
                currentCharacter = listCharacter[currentCharacterIndex];
            }
        } else {
            if((currentCharacterIndex - 1) >= 0) {
                currentCharacterIndex--;
                currentCharacter = listCharacter[currentCharacterIndex];
            }
        }
        continueButton.interactable = true;
        characterContainer.characterData = currentCharacter;
        nameInput.text = currentCharacter.name;
        characterContainer.UpdateSprite();
    }
}
