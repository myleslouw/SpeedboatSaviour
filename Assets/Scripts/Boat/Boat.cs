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

    public Slider durabiltySlider;
    
    // Update is called once per frame
    void Update()
    {
        durabiltySlider.value = Durabilty;
    }

    public void TakeDamage()
    {
        Durabilty -= Damage;
        if (Durabilty <= 0)
        {
            print("DEAD!");
        }
    }
}
