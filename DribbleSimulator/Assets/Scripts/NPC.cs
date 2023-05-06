using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour

{
    private Rigidbody2D physics;
    [SerializeField] float velocity = 5f;
    private Vector2 movement;
    private float Counter;

    void Start()
    {
        physics = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Counter -= Time.deltaTime;
        if (Counter <= 0) { 
            movement = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f));
            Counter = 2f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        movement = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f));
        Debug.Log("Choque");
    }

    void FixedUpdate()
    {
        physics.velocity = movement * velocity;
    }
}
