using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Tooltip("How Fast the Player Moves.")]
    [SerializeField] float playerSpeed = 3f;
    Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
	void Update () {

     Movement();
     
	}

    private void Movement()
    {
        float h = playerSpeed * Input.GetAxis("Horizontal");
        float v = playerSpeed * Input.GetAxis("Vertical");
        rigidBody.velocity = (new Vector2(h, v));
        
    }
}
