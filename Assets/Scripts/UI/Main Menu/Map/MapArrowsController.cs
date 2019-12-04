using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapArrowsController : MonoBehaviour
{
    GameObject arrowNext;
    GameObject arrowPrevious;

    // Start is called before the first frame update
    void Awake()
    {
        arrowNext = transform.Find("AnimatorArrowRight").gameObject;
        arrowPrevious = transform.Find("AnimatorArrowLeft").gameObject;
        arrowPrevious.GetComponentInChildren<Button>().onClick.AddListener(() => MapManager.instance.ChangeMap(false));
        arrowNext.GetComponentInChildren<Button>().onClick.AddListener(() => MapManager.instance.ChangeMap(true));
    }

    // Update is called once per frame
    void Update()
    {
        if(MapManager.instance.currentMapIndex == 0) {
            if( arrowPrevious.activeInHierarchy) {
                arrowPrevious.SetActive(false);
            }
        } else if (!arrowPrevious.activeInHierarchy) {
            arrowPrevious.SetActive(true);
        }

        if(MapManager.instance.currentMapIndex == (MapManager.instance.maps.Count - 1)) {
            if(arrowNext.activeInHierarchy) {
                arrowNext.SetActive(false);
            }
        } else if (!arrowNext.activeInHierarchy) {
            arrowNext.SetActive(true);
        }
    }
}
