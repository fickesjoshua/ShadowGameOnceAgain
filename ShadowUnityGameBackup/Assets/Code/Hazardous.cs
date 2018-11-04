using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Hazardous : MonoBehaviour {

    private AudioSource source;
    public AudioClip dieSound;
    public float soundVolume = 1;

    bool dead = false;
    public int xRespawn = 0;
    public int yRespawn = 0;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
    }

    //   void OnControllerColliderHit(ControllerColliderHit hit)
    //    {

    //        if (hit.gameObject.tag == "hazard")
    //      {
    //         dead = true;
    //        Debug.Log("found a death thing");
    //      }
    //              }
    //


    void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.tag == "hazard")
            {
                dead = true;
            //Debug.Log("found a dead thing");
            }
        }    

    // Update is called once per frame
    void Update () {

        if (dead)
        {
            //Debug.Log("omg im literally dying");
            source.PlayOneShot(dieSound, soundVolume);
            Vector2 v2 = new Vector2(xRespawn, yRespawn);
            transform.position = v2;
            dead = false;
        }
	}
}