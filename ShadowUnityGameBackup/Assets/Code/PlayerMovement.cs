using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;

	bool jump = false;

    Animator animator; //Get the animator connected to the player.

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw ("Horizontal") * runSpeed;

        if (horizontalMove == 0) //Check if player isstanding still or moving and changes animation.
        {
            animator.SetBool("IsRunning", false);
        } else
        {
            animator.SetBool("IsRunning", true);
        }

		if (Input.GetButtonDown ("Jump")) {
			jump = true;
            animator.SetTrigger("Jumps"); //Makes jump animation play.
        }

	}

	void FixedUpdate () {

		controller.Move (horizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;
	}
}
