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

    Vector3[] positions;
    System.Random rand = new System.Random();

    //dictionary to store the levelnum as key and an oil item which holds an array of oil positions and types
    Dictionary<int, OilItem> oilSpills = new Dictionary<int, OilItem>()
    {
        //1st level
        { 0, new OilItem(new OilInfo[]
        {
            new OilInfo(new Vector3(0, oilHeight, 0), 0),    //small
            new OilInfo(new Vector3(0, oilHeight, 1), 0),    //big
        })
        },

        //2nd level
        
        //3rd level

    };

    void Start()
    {
        positions = new Vector3[] { new Vector3(1, WATERHEIGHT, 1), new Vector3(4, WATERHEIGHT, -4), new Vector3(-1, WATERHEIGHT, 4), new Vector3(-10, WATERHEIGHT, 7), new Vector3(SpawnSpace / 4, WATERHEIGHT, SpawnSpace / 4), new Vector3(SpawnSpace / 3, WATERHEIGHT, SpawnSpace / -3), new Vector3(SpawnSpace / -4, WATERHEIGHT, SpawnSpace / 4) };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < positions.Length; i++)
            {
                SpawnPollutant(i);
            }

            for (int i = 0; i < oilSpills[0].OilSpillsInLevel.Length; i++)
            {
                Hazard spawnedHazard = new Hazard();
                int hazardType = oilSpills[0].OilSpillsInLevel[i].oilType;  //gets the oil type
                Vector3 oilPosition = oilSpills[0].OilSpillsInLevel[i].oilPosition;
                spawnedHazard = Instantiate(HazardOptions[hazardType], oilPosition, Quaternion.identity);
            }
        }
    }

    public void LoadLevel(int levelNum)
    {

    }
    public void SpawnPollutant(int index)
    {
        //creates a pollutant
        Pollutant spawnedObj = new Pollutant();
        spawnedObj = Instantiate(PollutantOptions[rand.Next(0,3)], positions[index], Quaternion.identity);
        //pollutants.Add(spawnedObj);
    }

}
