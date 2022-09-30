using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            //if the user presses any button or mouse button it will start the game from the menu at the beginning
            GameManager.StartGame();
        } 
    }
}
