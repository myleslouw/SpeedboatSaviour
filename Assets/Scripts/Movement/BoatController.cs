using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    Rigidbody rb;
    public Transform Director;
    public float speed = 3;        //speed for game, 1 for testing for some reason
    public AudioManager audioManager;
    bool playAudio;                 //when moving this will be set to true signalling to play audio

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioManager.Play("BoatSound");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //adding force to the rigidbody at position in the front of the gameobject to give it the right feel
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForceAtPosition(Vector3.forward * speed, Director.position, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForceAtPosition(Vector3.back * speed, Director.position, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForceAtPosition(Vector3.left * speed, Director.position, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForceAtPosition(Vector3.right * speed, Director.position, ForceMode.Force);
        }

    }
}
