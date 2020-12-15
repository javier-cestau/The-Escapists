using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemCollectable : MonoBehaviour
{
    public Item item;

    GameObject player;

    SpriteRenderer itemSpriteRenderer;

    void Awake()
    {
        itemSpriteRenderer = GetComponent<SpriteRenderer>();
        itemSpriteRenderer.sprite = item.icon;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnMouseOver()
    {
        if(Input.GetButtonDown("Fire1") && Time.timeScale == 1) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, .8f);
            if(hit.collider != null) {
                if(hit.collider.CompareTag("Player")) {
                    if(player.GetComponent<PlayerItems>().AddItem(item)) {
                        Destroy(gameObject);
                    };
                }
            }
        }
    }

}
