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

    private void OnTriggerEnter(Collider other)
    {
        //checks collision with pollutant
        if (other.gameObject.GetComponent<Pollutant>())
        {

            //Posts the event to all listeners of the POLLUTANT_PICKUP event and sends the pollutant for listeners to use
            EventManager.Instance.PostEventNotification(EventManager.EVENT_TYPE.POLLUTANT_PICKUP, this, other.gameObject.GetComponent<Pollutant>());

            //Destroys obj
            Destroy(other.gameObject);
        }

        //checks collision with recycler
        if (other.gameObject.GetComponent<PollutantRecycler>())
        {
            print("Recycler Collision");
            //if the player collides with a recycler, it will trigger the recycle event
            EventManager.Instance.PostEventNotification(EventManager.EVENT_TYPE.RECYCLE_POLLUTANT, this, other.gameObject.GetComponent<PollutantRecycler>());
        }
    }
}
