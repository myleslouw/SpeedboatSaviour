using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //key is the type and the value is the type amount
    public Dictionary<PollutantType.type, int> PollutantInventory;

    public static Inventory Instance
    {
        get { return instance; }
        set { }
    }

    private static Inventory instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    private void Start()
    {
        //creates the inventory dictionary
        CreateInventory();

        //creates the delegates and the methods to it
        EventManager.OnDelegateEvent AddPollutantDelegate = AddToInventory;
        EventManager.OnDelegateEvent RecyclePollutantDelegate = RecycleType;
        //becomes a listener for the POLLUTANT_PICKUP event
        EventManager.Instance.AddListener(EventManager.EVENT_TYPE.POLLUTANT_PICKUP, AddPollutantDelegate);
        EventManager.Instance.AddListener(EventManager.EVENT_TYPE.RECYCLE_POLLUTANT, RecyclePollutantDelegate);
    }

    private void CreateInventory()
    {
        //create the inv dictionary
        PollutantInventory = new Dictionary<PollutantType.type, int>();

        //adds the types and starts them at 0
        PollutantInventory.Add(PollutantType.type.Glass, 0);
        PollutantInventory.Add(PollutantType.type.Plastic, 0);
        PollutantInventory.Add(PollutantType.type.GeneralWaste, 0);

    }

    private void AddToInventory(EventManager.EVENT_TYPE eventType, Component sender, object Params = null)
    {
        //casts the obj recieved from the event to a pollutant and then increments the count in inv based on type
        Pollutant pickedUpPollutant = (Pollutant)Params;

        //increments the value of the type in the dictionary
        int count;
        count = PollutantInventory[pickedUpPollutant.pollutantObj.pollutantType];
        PollutantInventory[pickedUpPollutant.pollutantObj.pollutantType] = count + 1;

        //UI event becuase the UI would pudate before it was added to inv
        EventManager.Instance.PostEventNotification(EventManager.EVENT_TYPE.PICKUP_UI, this, pickedUpPollutant);
    }

    private void RecycleType(EventManager.EVENT_TYPE eventType, Component sender, object Params = null)
    {
        //gets the type calls ADD xp event and then sets the inventory count of that type to 0
        //gets the event obj data
        PollutantRecycler recycler = (PollutantRecycler)Params;

        if (PollutantInventory[recycler.recyclerType] != 0)
        {
            //if the inventory isnt empty it should play a sound when recycling
            GetComponent<AudioManager>().Play("Recycle");
            WaveSoundAfterRecycle();
        }



        //ADD XP event
        EventManager.Instance.PostEventNotification(EventManager.EVENT_TYPE.ADD_XP, this, recycler);

        //sets the types amount in inv to 0
        PollutantInventory[recycler.recyclerType] = 0;

        //it then updaes the UI to show the 0 in invetory
        EventManager.Instance.PostEventNotification(EventManager.EVENT_TYPE.RECYCLE_UI, this, recycler);
    }

    private async Task WaveSoundAfterRecycle()
    {
        //waits for the recycle sound to finish before playing the wave ambience
        await System.Threading.Tasks.Task.Delay(2200);
        GetComponent<AudioManager>().Play("WaveAmbience");
    }

}
