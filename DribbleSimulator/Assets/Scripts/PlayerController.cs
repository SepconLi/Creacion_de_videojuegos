using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D physics;
    Animator animation;
    [SerializeField] float velocity = 5f;
    [SerializeField] float rotation = 0f; 
    private Vector2 movement;

    void Start() {
        physics = gameObject.GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
    }

    void FixedUpdate() {
        physics.velocity = movement * velocity;
        physics.rotation = rotation * 100;
        if(Input.anyKey == false) {
            animation.SetBool("PlayerRun",false);
        }
    }
    void OnMove(InputValue inputValue){
        animation.SetBool("PlayerRun",true);
        movement = inputValue.Get<Vector2>();
        rotation = movement.y;
        if (movement.x < 0) {
            physics.transform.localScale = new Vector2(-1, 1);
            rotation *= -1;
        } else {
            physics.transform.localScale = new Vector2(1, 1);
        }
        Debug.Log(movement);
    }

}
