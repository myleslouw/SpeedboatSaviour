
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject NPCSinLevel;
    [SerializeField] Transform SpawnPoint;
    

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
