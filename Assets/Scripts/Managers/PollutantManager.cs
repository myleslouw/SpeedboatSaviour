using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollutantManager : MonoBehaviour
{
    //used for creating and storing pollutants
    //when creating it randoms a pollutant type and gives it a reward for recycling based on the type
    [SerializeField] Pollutant[] PollutantOptions = new Pollutant[2];
    [SerializeField] Hazard[] HazardOptions = new Hazard[1];

    const float WATERHEIGHT = 4.1f; //height of water so pollutants look like theyre floating
    const int SpawnSpace = 20;
    const float oilHeight = 3.6f;      //the height the oil will be (just below water)

    private int currentLevelNum;

    System.Random rand = new System.Random();

   
    //dictionary to store the levelnum as key and an oil item which holds an array of oil positions and types
    Dictionary<int, OilItem> oilSpills = new Dictionary<int, OilItem>()
    {
        //1st level
        { 0, new OilItem(new OilInfo[]
        {
            new OilInfo(new Vector3(-3, oilHeight, 2), 0),    //small
            new OilInfo(new Vector3(4, oilHeight, 2), 1),    //big
            new OilInfo(new Vector3(14, oilHeight, -5), 0),    //small
            new OilInfo(new Vector3(-9, oilHeight, -4), 1),    //big
            new OilInfo(new Vector3(7, oilHeight, -14), 0),    //small
            new OilInfo(new Vector3(10, oilHeight, 10), 1),    //big
            new OilInfo(new Vector3(-3, oilHeight, 8), 1),    //big
            new OilInfo(new Vector3(-5, oilHeight, -10), 0),    //small
            new OilInfo(new Vector3(-3, oilHeight, -16), 0),    //small
        })
        },

        //2nd level
        
        //3rd level

    };


    void Start()
    {
        currentLevelNum = GameManager.Level;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < 7; i++)
            {
                SpawnPollutant();
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            //spawns the oil spills for that level
            for (int i = 0; i < oilSpills[currentLevelNum].OilSpillsInLevel.Length; i++)
            {

                Hazard spawnedHazard = new Hazard();
                int hazardType = oilSpills[0].OilSpillsInLevel[i].oilType;  //gets the oil type
                Vector3 oilPosition = oilSpills[0].OilSpillsInLevel[i].oilPosition;                         //  vv   spawns flat and at a random angle
                spawnedHazard = Instantiate(HazardOptions[hazardType], oilPosition, Quaternion.Euler(new Vector3(-90, 0, rand.Next(0, 180))));
            }
        }
    }

    public void LoadLevel(int levelNum)
    {

    }
    public void SpawnPollutant()
    {
        //creates a pollutant
        Pollutant spawnedObj = new Pollutant();
        spawnedObj = Instantiate(PollutantOptions[rand.Next(0,3)], new Vector3(rand.Next(-14,15), WATERHEIGHT, rand.Next(-19,14)), Quaternion.identity);
        //pollutants.Add(spawnedObj);
    }

}
