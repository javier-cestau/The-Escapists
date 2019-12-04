using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectorNPC : MonoBehaviour, IPointerClickHandler
{
    public static CharacterData currentNPCSelected;
    public static bool isCurrentNPCSelectedClicked = false;
    Image selectorImage;
    CharacterData characterData;

    public InputField inputName;
    // Start is called before the first frame update
    void Start()
    {
        characterData = GetComponent<CharacterContainer>().characterData;
        selectorImage = GetComponentInChildren<Image>();
        selectorImage.enabled = false;
    }

    void Update()
    {
        if(currentNPCSelected == characterData) {
            selectorImage.enabled = true;
        } else {
            selectorImage.color = Color.white;
            selectorImage.enabled = false;
        }
    }

    public void OnMouseEnter()
    {
        currentNPCSelected = characterData;
    }

    public void OnMouseExit()
    {
        selectorImage.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData) {
        isCurrentNPCSelectedClicked = true;
        selectorImage.color = Color.yellow;
    }

}
