using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectionArrowsController : MonoBehaviour
{
    public GameObject arrowNext;
    public GameObject arrowPrevious;

    SelectPlayer selectPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        selectPlayer = GetComponentInChildren<SelectPlayer>();
        arrowPrevious.GetComponentInChildren<Button>().onClick.AddListener(() => selectPlayer.ChangeCharacter(false));
        arrowNext.GetComponentInChildren<Button>().onClick.AddListener(() => selectPlayer.ChangeCharacter(true));
    }

    // Update is called once per frame
    void Update()
    {
        if(selectPlayer.currentCharacterIndex == 0) {
            if( arrowPrevious.activeInHierarchy) {
                arrowPrevious.SetActive(false);
            }
        } else if (!arrowPrevious.activeInHierarchy) {
            arrowPrevious.SetActive(true);
        }

        if(selectPlayer.currentCharacterIndex == (selectPlayer.listCharacter.Count - 1)) {
            if(arrowNext.activeInHierarchy) {
                arrowNext.SetActive(false);
            }
        } else if (!arrowNext.activeInHierarchy) {
            arrowNext.SetActive(true);
        }
    }
}
