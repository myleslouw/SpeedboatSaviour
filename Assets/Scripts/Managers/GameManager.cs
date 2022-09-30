using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GetComponent<AudioManager>();
        audioManager.Play("WaveAmbience");

    }

    public static void StartGame()
    {
        //changes scene from menu to game (Called in MenuManager)
        SceneManager.LoadScene(1);
    }

}
