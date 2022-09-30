using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    Rigidbody rb;
    public Transform Director;
    public float speed = 3;        //speed for game, 1 for testing for some reason
    public AudioManager audioManager;
    public SoundObj soundObj;
    bool moving;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        //sets the source of the sound to this game object
        soundObj.source = GetComponent<AudioSource>();
        //adds the sound to the list of sounds
        audioManager.AddSoundToList(soundObj);
        
    }
    private void Start()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (!Input.anyKey)
        {
            //IF THERE IS NO MOVEMENT
            moving = false;
        }

        //adding force to the rigidbody at position in the front of the gameobject to give it the right feel
        if (Input.GetKey(KeyCode.W))
        {
            moving = true;
            rb.AddForceAtPosition(Vector3.forward * speed, Director.position, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.S))
        {
            moving = true;
            rb.AddForceAtPosition(Vector3.back * speed, Director.position, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            moving = true;
            rb.AddForceAtPosition(Vector3.left * speed, Director.position, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.D))
        {
            moving = true;
            rb.AddForceAtPosition(Vector3.right * speed, Director.position, ForceMode.Force);
        }

        //boat sounds
        if (moving && !audioManager.getSoundStatus("BoatSound"))
        {
            //if the boat is moving and the sound isnt playing, it will play the sound
            audioManager.Play("BoatSound");
        }

        if (!moving && audioManager.getSoundStatus("BoatSound"))
        {
            //if the boat isnt moving and a sound is playing, it will stop
            audioManager.StopPlaying("BoatSound");
        }
    }
}
