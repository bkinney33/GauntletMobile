using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerMovement : MonoBehaviour {

    [Tooltip("How Fast the Player Moves.")]
    [SerializeField] float playerSpeed = 3f;
    Rigidbody2D rigidBody;
    Transform body;
    Component transform;

    private void Start()
    {
        body = gameObject.GetComponent<Transform>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        transform = gameObject.transform.Find("Body");

    }

    // Update is called once per frame
	void Update () {

     Movement();
     
	}

    private void Movement()
    {
        float currentX = body.position.x;
        float currentY = body.position.y;
   
        float h = playerSpeed * CrossPlatformInputManager.GetAxis("Horizontal");
        float v = playerSpeed * CrossPlatformInputManager.GetAxis("Vertical");
        rigidBody.velocity = (new Vector2(h, v));
        float heading = Mathf.Atan2(CrossPlatformInputManager.GetAxis("Horizontal"),-CrossPlatformInputManager.GetAxis("Vertical"));
       
        transform.transform.rotation = Quaternion.Euler(0f, 0f, (((heading) * Mathf.Rad2Deg)));
      
   


}
}
