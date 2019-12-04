using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContainer : MonoBehaviour
{
    public CharacterData characterData;

    Animator head;
    Animator body;

    // Start is called before the first frame update
    void Start()
    {
        head = transform.Find("Head").GetComponent<Animator>();
        body = transform.Find("Body").GetComponent<Animator>();
        head.runtimeAnimatorController = characterData.head;
        body.runtimeAnimatorController = characterData.body;
    }

    void Update()
    {
        UpdateSprite();
    }
    public void UpdateSprite()
    {
        if (head.runtimeAnimatorController != characterData.head) {
            head.runtimeAnimatorController = characterData.head;
        }
        if (body.runtimeAnimatorController != characterData.body) {
            body.runtimeAnimatorController = characterData.body;
        }
    }
}
