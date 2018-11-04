using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public AudioSource source;
    //public AudioClip runSound;
    //public float runVolume = 1;
    public AudioClip jumpSound;
    public float jumpVolume = 1;


    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;

    Animator animator; //Get the animator connected to the player.

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (horizontalMove == 0) //Check if player isstanding still or moving and changes animation.
        {
            animator.SetBool("IsRunning", false);
            //source.Stop();
        }
        else
        {
            animator.SetBool("IsRunning", true);
            //source.Play();
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetTrigger("Jumps"); //Makes jump animation play.
            source.PlayOneShot(jumpSound, jumpVolume);
        }

    }

    void FixedUpdate()
    {

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
