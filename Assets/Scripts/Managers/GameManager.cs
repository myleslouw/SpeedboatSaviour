using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int Level = 0;
    AudioManager audioManager;
    GameObject DurabilitySlider;

    [SerializeField] GameObject[] BoatSelection;

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

    public static void ChangeLevel()
    {
        //loads the scene again with the relevant data for the level
        SceneManager.LoadScene(1);

    }
    public void ChangeBoat()
    {

    }
}
