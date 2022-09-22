using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text glassCounter, plasticCounter, generalWasteCounter;
    private Dictionary<PollutantType.type, Text> TypeCounters;

    // Start is called before the first frame update

    private void Start()
    {
        //puts the counters in the dictionary
        CreateCounters();

        //the listener for the pickup event
        EventManager.OnDelegateEvent IncrementDelegate = IncrementPollutantUI;
        EventManager.OnDelegateEvent ResetDelegate = ResetPollutantUI;
        EventManager.OnDelegateEvent LevelUpDelegate = LevelUpUI;
        EventManager.Instance.AddListener(EventManager.EVENT_TYPE.PICKUP_UI, IncrementDelegate);
        EventManager.Instance.AddListener(EventManager.EVENT_TYPE.RECYCLE_UI, ResetDelegate);
        EventManager.Instance.AddListener(EventManager.EVENT_TYPE.LEVEL_UP, LevelUpDelegate);
    }
    private void CreateCounters()
    {
        //create the inv dictionary
        TypeCounters = new Dictionary<PollutantType.type, Text>();

        //adds the types and corresponding counter UI component
        TypeCounters.Add(PollutantType.type.Glass, glassCounter);
        TypeCounters.Add(PollutantType.type.Plastic, plasticCounter);
        TypeCounters.Add(PollutantType.type.GeneralWaste, generalWasteCounter);

    }
    private void IncrementPollutantUI(EventManager.EVENT_TYPE eventType, Component sender, object Params = null)
    {
        //this is be exectured on event trigger,   there a few components it can access ^^
        //gets the pollutant object to see what type to increment

        Pollutant pickedUpObj = (Pollutant)Params;       //gets the object sent and casts it so we can use it

        //runs the method that disaplys the current inv
        UpdatePollutantCount(pickedUpObj.pollutantObj.pollutantType);
    }

    private void ResetPollutantUI(EventManager.EVENT_TYPE eventType, Component sender, object Params = null)
    {
        //upon recycling the inv amount for a type will be 0 so it will be updated
        PollutantRecycler recycler = (PollutantRecycler)Params;
        UpdatePollutantCount(recycler.recyclerType);
    }

    private void UpdatePollutantCount(PollutantType.type polObjType)
    {
        //gets the UI components based on the type and then displays the types inventory count

        TypeCounters[polObjType].text = Inventory.Instance.PollutantInventory[polObjType].ToString();
    }

    private void LevelUpUI(EventManager.EVENT_TYPE eventType, Component sender, object Params = null)
    {
        //change the UI to show new level
    }
}
