using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollutant : MonoBehaviour
{
    public PollutantObject pollutantObj;        //the pollutant scriptable object
    
    void Start()
    {   //GW must be sideways at start others dont use this
        transform.Rotate(pollutantObj.startOffset);

        //the listener for the pickup event
        EventManager.OnDelegateEvent PickupAnimationDelegate = PickUpAnimation;
        //EventManager.Instance.AddListener(EventManager.EVENT_TYPE.POLLUTANT_PICKUP, PickupPollutant);
        EventManager.Instance.AddListener(EventManager.EVENT_TYPE.POLLUTANT_PICKUP, PickupAnimationDelegate);
    }
    private void Update()
    {
        //rotation of the object based on type
        transform.Rotate(pollutantObj.pollutantRotation);
    }

    private void PickUpAnimation(EventManager.EVENT_TYPE eventType, Component sender, object Param = null)
    {
        //StartCoroutine();
    }
    
    
}
