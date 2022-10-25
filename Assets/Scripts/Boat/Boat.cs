using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            print("DEAD!");
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
}
