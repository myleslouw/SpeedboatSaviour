using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//HANDLES PLAYER COLLISION
public class PlayerScript : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //TRIGGER ONCE
    private void OnTriggerEnter(Collider other)
    {
        GameObject collisionObj = other.gameObject;

        //checks collision with pollutant
        if (collisionObj.GetComponent<Pollutant>())
        {

            //Posts the event to all listeners of the POLLUTANT_PICKUP event and sends the pollutant for listeners to use
            EventManager.Instance.PostEventNotification(EventManager.EVENT_TYPE.POLLUTANT_PICKUP, this, collisionObj.GetComponent<Pollutant>());

            //plays the animation and destroys the obj
            collisionObj.GetComponent<Pollutant>().PickUpAnimation();
        }

        //checks collision with recycler
        if (collisionObj.GetComponent<PollutantRecycler>())
        {
            //if the player collides with a recycler, it will trigger the recycle event
            EventManager.Instance.PostEventNotification(EventManager.EVENT_TYPE.RECYCLE_POLLUTANT, this, collisionObj.GetComponent<PollutantRecycler>());
        }

        //collision with NPC collider
        if (collisionObj.GetComponent<NPC>())
        {
            //if player collides with NPC collider it will trigger the NPC talk event 
            EventManager.Instance.PostEventNotification(EventManager.EVENT_TYPE.NPC_TALK, this, collisionObj.GetComponent<NPC>());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<NPC>())
        {
            EventManager.Instance.PostEventNotification(EventManager.EVENT_TYPE.NPC_LEAVE, this, null);
        }
    }

    //TRIGGER WHILE TOUCHING
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Hazard>())
        {
            //if the player touches a hazard, it will damage WHILE the player touches it
            GetComponent<Boat>().TakeDamage();
        }
    }
}
