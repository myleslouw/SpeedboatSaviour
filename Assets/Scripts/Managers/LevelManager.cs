
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject[] NPCSinLevel;            //empty that holds the NPCs as children in their respective positions (Index is the level num)
    [SerializeField] Transform[] SpawnPoints;              //the spawning point for the pollution to spawn around               (index is the level num)

    [SerializeField] GameObject PrevArea;               //the area the player was prev in/just finished must now be enabled which shows the fish/sea life

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int levelNum)
    {
        //when a level is loaded
        //it should spawn the player in the spot designated for that level
        //spawn the relevant NPCs for that level

    }
}
