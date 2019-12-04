using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    const string VERTICAL = "Vertical", HORIZONTAL = "Horizontal";
    float speed = 5f;

    float previousXMovement = 0;
    float previousYMovement = 0;
    Rigidbody2D playerRigidbody;

    Animator bodyAnimator;
    Animator headAnimator;

    Vector2 movement;

    CharacterContainer dataContainer;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        bodyAnimator = transform.Find("Body").GetComponent<Animator>();
        CharacterContainer characterContainer = GetComponent<CharacterContainer>();
        bodyAnimator.runtimeAnimatorController = characterContainer.characterData.body;
        headAnimator = transform.Find("Head").GetComponent<Animator>();
        headAnimator.runtimeAnimatorController = characterContainer.characterData.head;
        dataContainer = GetComponent<CharacterContainer>();
        speed = dataContainer.characterData.speed;
    }

    // Update is called once per frame
    void Update()
    {
        movement.y = Input.GetAxisRaw(VERTICAL);
        movement.x = Input.GetAxisRaw(HORIZONTAL);
        if(movement.x != 0 || movement.y != 0 ) {
            bodyAnimator.SetFloat(VERTICAL, movement.y);
            bodyAnimator.SetFloat(HORIZONTAL, movement.x);
            headAnimator.SetFloat(HORIZONTAL, movement.x);
            headAnimator.SetFloat(VERTICAL, movement.x == 0 ? movement.y : 0); // Condition to avoid weird animation on diagonal
            if(previousXMovement != movement.x) {
                // SYNC Animations for Right and left in order to start at the same time
                previousXMovement = movement.x;
                headAnimator.Play("Movement",-1, 0);
                bodyAnimator.Play("Movement",-1, 0);
            }
        }

    }

    void FixedUpdate()
    {
        playerRigidbody.MovePosition((playerRigidbody.position + (movement * Time.fixedDeltaTime * (speed/10))));
    }

}
