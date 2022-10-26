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

    private void Start()
    {
        EventManager.OnDelegateEvent RefuelDelegate = RefuelBoat;
        EventManager.Instance.AddListener(EventManager.EVENT_TYPE.REFUEL, RefuelDelegate);
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
        print("Amount recieved: " + fuelRefill);
        //add the refill amount to the boats current fuel if its not full
        if (!(Fuel >= 100))
        {
            Fuel += fuelRefill;

        }
    }
}
