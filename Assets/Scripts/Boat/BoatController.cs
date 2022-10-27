using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    Rigidbody rb;
    public Transform Director;
    public float speed = 3;        //speed for game, 
    public AudioManager audioManager;
    public SoundObj soundObj;
    bool moving;
    public GameObject propeller;
    public Boat Boat;


    //OLD BOAT HEIGHT WAS 3.9 for row boat
    //3.689 for sail
    //3.652 for speedboat



    //NEW BOAT HEIGHT 0.7

    private void Awake()
    {
        //rb = GetComponent<Rigidbody>();

        ////sets the source of the sound to this game object
        //soundObj.source = GetComponent<AudioSource>();
        ////adds the sound to the list of sounds
        //audioManager.AddSoundToList(soundObj);
        
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Boat = GetComponent<Boat>();
        //sets the source of the sound to this game object
        soundObj.source = GetComponent<AudioSource>();
        //adds the sound to the list of sounds
        audioManager.AddSoundToList(soundObj);
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
            //move forward
            MoveBoat(-transform.up);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //move back
            MoveBoat(transform.up);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //turn left
            TurnBoat(-transform.right);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //turn right
            TurnBoat(transform.right);
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

        if (moving)
        {
            Boat.UseFuel();
        }
    }

    private void MoveBoat(Vector3 direction)
    {

        moving = true;

        rb.AddForceAtPosition(direction * speed, Director.position, ForceMode.Force);


        //spin the propeller if it has one
        if (propeller != null)
        {
            propeller.transform.Rotate(new Vector3(0, 30, 0));
        }
    }

    private void TurnBoat(Vector3 direction)
    {

        //same as the moving but it is half the speed for turning
        moving = true;

        rb.AddForceAtPosition(direction * speed/2, Director.position, ForceMode.Force);

        //spin the propeller if it has one
        if (propeller != null)
        {
            propeller.transform.Rotate(new Vector3(0, 30, 0));
        }
    }
}
