using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunSoundManager : MonoBehaviour {

    private AudioSource source;
    public AudioClip runSound;
    public float runVolume = 1;
    private bool playing = false;

    // Use this for initialization
    void Start () {

        source = GetComponent<AudioSource>();
        source.Stop();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (playing == false)
            {
                //Debug.Log("playing");
                source.Play();
                playing = true;
            }
        
            
        } else
        {
            source.Stop();
            //Debug.Log("Stopping");
            playing = false;
        }
	}
}
