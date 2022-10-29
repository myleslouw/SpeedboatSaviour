using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Boat : MonoBehaviour
{
    //the durability of the boat
    public int Durabilty;
    //the amount of damage the boat takes per tick
    public int Damage;
    //the amount of fuel the boat can hold
    public float Fuel;
    //the amount of fuel the boat uses per tick
    public float FuelConsumption;

    public GameObject cameraTarget;

    public Slider durabiltySlider;

    public Slider fuelSlider;

    public Transform onBoardGlass;
    public Transform[] onBoardGlassArray;

    public Transform onBoardPlastic;
    public Transform[] onBoardPlasticBottles;
    public Transform[] onBoardPlasticBags;

    public Transform onBoardGeneralWaste;
    public Transform[] onBoardGWCans;
    public Transform[] onBoardPlasticTakeaway;
    public Transform[] onBoardGWCoffee;
    public Transform[] onBoardGWTrash;

    int glassIndex = 1, bottlesIndex = 1, bagsIndex = 1, cansIndex = 1, trashIndex = 1, coffeeIndex = 1, takeawayIndex = 1;

    private void Start()
    {
        EventManager.OnDelegateEvent RefuelDelegate = RefuelBoat;
        EventManager.OnDelegateEvent PickupDelegate = PickupPollutant;
        EventManager.OnDelegateEvent ClearBoatDelegate = RemovePollutants;
        EventManager.Instance.AddListener(EventManager.EVENT_TYPE.REFUEL, RefuelDelegate);
        EventManager.Instance.AddListener(EventManager.EVENT_TYPE.POLLUTANT_PICKUP, PickupDelegate);
        EventManager.Instance.AddListener(EventManager.EVENT_TYPE.RECYCLE_POLLUTANT, ClearBoatDelegate);

        //ALL THE POLLUTANT POSITIONS IN THE BOAT LOADED INTO ARRAY
        //gets all the glass items in an array
        onBoardGlassArray = onBoardGlass.GetComponentsInChildren<Transform>();
        //gets the plastic bottles from within the child
        onBoardPlasticBottles = onBoardPlastic.GetChild(0).GetComponentsInChildren<Transform>();
        //gets the plastic bags from within the child
        onBoardPlasticBags = onBoardPlastic.GetChild(1).GetComponentsInChildren<Transform>();
        //all the cans
        onBoardGWCans = onBoardGeneralWaste.GetChild(0).GetComponentsInChildren<Transform>();
        //trashbags
        onBoardGWTrash = onBoardGeneralWaste.GetChild(1).GetComponentsInChildren<Transform>();
        //coffee cups
        onBoardGWCoffee = onBoardGeneralWaste.GetChild(2).GetComponentsInChildren<Transform>();
        //takeaway containers
        onBoardPlasticTakeaway = onBoardGeneralWaste.GetChild(3).GetComponentsInChildren<Transform>();

        //clears all the trash off the boat
        ClearBoat();

        //make sure the parent objects are active for trash collection
        onBoardGlass.gameObject.SetActive(true);
        onBoardPlastic.GetChild(0).gameObject.SetActive(true);
        onBoardPlastic.GetChild(1).gameObject.SetActive(true);
        onBoardGeneralWaste.GetChild(0).gameObject.SetActive(true);
        onBoardGeneralWaste.GetChild(1).gameObject.SetActive(true);
        onBoardGeneralWaste.GetChild(2).gameObject.SetActive(true);
        onBoardGeneralWaste.GetChild(3).gameObject.SetActive(true);
}

    // Update is called once per frame
    void Update()
    {
        durabiltySlider.value = Durabilty;
        fuelSlider.value = Fuel;

    }

    public void TakeDamage()
    {
        Durabilty -= Damage;
        if (Durabilty <= 0)
        {
            EventManager.Instance.PostEventNotification(EventManager.EVENT_TYPE.GAME_END, this, null);
            Durabilty = 100;
            SceneManager.LoadScene(2);
        }
    }

    public void UseFuel()
    {
        Fuel -= FuelConsumption;
        if (Fuel <= 0)
        {
            print("OUT OF FUEL!!!");
        }
    }

    public void RefuelBoat(EventManager.EVENT_TYPE eventType, Component sender, object Params = null)
    {
        print("REFUELING...");
        //get the fuel object from the event
        int fuelRefill = (int)Params;
        //add the refill amount to the boats current fuel if its not full
        if (!(Fuel >= 100))
        {
            Fuel += fuelRefill;
        }
    }

    public void PickupPollutant(EventManager.EVENT_TYPE eventType, Component sender, object Params = null)
    {
        //gets the type of pollutant picked up and shows it in the boat

        //gets pollutant from event
        Pollutant pollutant = (Pollutant)Params;

        //depending on what type 
        switch (pollutant.pollutantObj.pollutantType)
        {
            case PollutantType.type.Glass:
                //THERE ARE ONLY GLASS BOTTLES
                //sets an item of that type to show in the boat
                onBoardGlassArray[glassIndex].gameObject.SetActive(true);
                if (!(glassIndex >= onBoardGlassArray.Length))
                {
                    glassIndex++;
                }

                break;
            case PollutantType.type.Plastic:

                //checks if it is a plastic bottle or bag
                //sets an item of that type to show in the boat
                //onBoardPlasticArray[plasticIndex].gameObject.SetActive(true);
                switch (pollutant.subType)
                {
                    case PollutantType.subType.bottles:

                        onBoardPlasticBottles[bottlesIndex].gameObject.SetActive(true);
                        if (!(bottlesIndex >= (onBoardPlasticBottles.Length - 1)))
                        {
                            bottlesIndex++;
                        }
                        break;
                    case PollutantType.subType.bags:

                        onBoardPlasticBags[bagsIndex].gameObject.SetActive(true);
                        if (!(bagsIndex >= (onBoardPlasticBags.Length - 1)))
                        {
                            bagsIndex++;
                        }
                        break;
                    case PollutantType.subType.takeaway:

                        onBoardPlasticTakeaway[takeawayIndex].gameObject.SetActive(true);
                        if (!(takeawayIndex >= (onBoardPlasticTakeaway.Length - 1)))
                        {
                            takeawayIndex++;
                        }

                        break;
                }

                break;
            case PollutantType.type.GeneralWaste:

                //checks if its trash, cans, takeaway or coffee
                //sets an item of that type to show in the boat
                //onBoardGeneralWasteArray[generalWasteIndex].gameObject.SetActive(true);
                switch (pollutant.subType)
                {
                    case PollutantType.subType.cans:

                        onBoardGWCans[cansIndex].gameObject.SetActive(true);
                        if (!(cansIndex >= (onBoardGWCans.Length - 1)))
                        {
                            cansIndex++;
                        }

                        break;
                    case PollutantType.subType.trash:

                        onBoardGWTrash[trashIndex].gameObject.SetActive(true);
                        if (!(trashIndex >= (onBoardGWTrash.Length - 1)))
                        {
                            trashIndex++;
                        }

                        break;
                    case PollutantType.subType.coffee:

                        onBoardGWCoffee[coffeeIndex].gameObject.SetActive(true);
                        if (!(coffeeIndex >= (onBoardGWCoffee.Length - 1)))
                        {
                            coffeeIndex++;
                        }

                        break;
                    default:
                        break;
                }

                break;
            default:
                break;  
        }
    }

    public void RemovePollutants(EventManager.EVENT_TYPE eventType, Component sender, object Params = null)
    {
        //gets the recylcer type
        PollutantRecycler recyclerType = (PollutantRecycler)Params;

        switch (recyclerType.recyclerType)
        {
            case PollutantType.type.Glass:

                glassIndex = 1;

                foreach (Transform item in onBoardGlassArray)
                {
                    item.gameObject.SetActive(false);
                }

                //otherwise the parent is hidden
                onBoardGlassArray[0].gameObject.SetActive(true);

                break;
            case PollutantType.type.Plastic:

                //resets the index 
                takeawayIndex = 1;
                bagsIndex = 1;
                bottlesIndex = 1;

                //hides those polltants on the boat
                foreach (Transform item in onBoardPlasticTakeaway)
                {
                    item.gameObject.SetActive(false);
                }

                foreach (Transform item in onBoardPlasticBottles)
                {
                    item.gameObject.SetActive(false);
                }

                foreach (Transform item in onBoardPlasticBags)
                {
                    item.gameObject.SetActive(false);
                }

                //keeps parents active
                onBoardPlasticBags[0].gameObject.SetActive(true);
                onBoardPlasticBottles[0].gameObject.SetActive(true);
                onBoardPlasticTakeaway[0].gameObject.SetActive(true);

                break;
            case PollutantType.type.GeneralWaste:

                //resets the index 
                trashIndex = 1;
                cansIndex = 1;
                coffeeIndex = 1;

                //hides those polltants on the boat
                foreach (Transform item in onBoardGWTrash)
                {
                    item.gameObject.SetActive(false);
                }

                foreach (Transform item in onBoardGWCans)
                {
                    item.gameObject.SetActive(false);
                }

                foreach (Transform item in onBoardGWCoffee)
                {
                    item.gameObject.SetActive(false);
                }

                onBoardGWCans[0].gameObject.SetActive(true);
                onBoardGWCoffee[0].gameObject.SetActive(true);
                onBoardGWTrash[0].gameObject.SetActive(true);

                break;
            default:
                break;
        }
    }

    private void ClearBoat()
    {

        //hides all the pollutants on the boat
        foreach (Transform item in onBoardGlassArray)
        {
            item.gameObject.SetActive(false);
        }

        foreach (Transform item in onBoardPlasticBottles)
        {
            item.gameObject.SetActive(false);
        }

        foreach (Transform item in onBoardPlasticBags)
        {
            item.gameObject.SetActive(false);
        }

        foreach (Transform item in onBoardGWCans)
        {
            item.gameObject.SetActive(false);
        }

        foreach (Transform item in onBoardGWTrash)
        {
            item.gameObject.SetActive(false);
        }
        foreach (Transform item in onBoardGWCoffee)
        {
            item.gameObject.SetActive(false);
        }

        foreach (Transform item in onBoardPlasticTakeaway)
        {
            item.gameObject.SetActive(false);
        }
    }
}
