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

    public Slider durabiltySlider;

    public Slider fuelSlider;

    public Transform onBoardGlass;
    public Transform[] onBoardGlassArray;

    public Transform onBoardPlastic;
    public Transform[] onBoardPlasticBottles;
    public Transform[] onBoardPlasticBags;

    public Transform onBoardGeneralWaste;
    public Transform[] onBoardGWCans;
    public Transform[] onBoardGWTakeaway;
    public Transform[] onBoardGWCoffee;
    public Transform[] onBoardGWTrash;

    public int glassIndex = 1;
    public int plasticIndex = 1;
    public int generalWasteIndex = 1;

    private void Start()
    {
        EventManager.OnDelegateEvent RefuelDelegate = RefuelBoat;
        EventManager.OnDelegateEvent PickupDelegate = PickupPollutant;
        EventManager.Instance.AddListener(EventManager.EVENT_TYPE.REFUEL, RefuelDelegate);
        EventManager.Instance.AddListener(EventManager.EVENT_TYPE.POLLUTANT_PICKUP, PickupDelegate);

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
        onBoardGWTakeaway = onBoardGeneralWaste.GetChild(3).GetComponentsInChildren<Transform>();

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

        foreach (Transform item in onBoardGWTakeaway)
        {
            item.gameObject.SetActive(false);
        }
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
                //sets an item of that type to show in the boat
                onBoardGlassArray[glassIndex].gameObject.SetActive(true);
                glassIndex++;

                break;
            case PollutantType.type.Plastic:

                //sets an item of that type to show in the boat
                //onBoardPlasticArray[plasticIndex].gameObject.SetActive(true);
                onBoardPlasticBags[plasticIndex].gameObject.SetActive(true);
                plasticIndex++;

                break;
            case PollutantType.type.GeneralWaste:

                //sets an item of that type to show in the boat
                //onBoardGeneralWasteArray[generalWasteIndex].gameObject.SetActive(true);
                generalWasteIndex++;

                break;
            default:
                break;  
        }
    }
}
