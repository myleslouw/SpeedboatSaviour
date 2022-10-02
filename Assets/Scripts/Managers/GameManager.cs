using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int Level = 0;
    AudioManager audioManager;
    public Slider DurabilitySlider;
    int currentBoat;
    [SerializeField] GameObject[] BoatSelection;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GetComponent<AudioManager>();
        audioManager.Play("WaveAmbience");
        currentBoat = 0;
        SetBoat(currentBoat);

        EventManager.OnDelegateEvent NewBoatDelegate = ChangeBoat;
        EventManager.Instance.AddListener(EventManager.EVENT_TYPE.UPGRADE_BOAT, NewBoatDelegate);
    }

    public void ChangeBoat(EventManager.EVENT_TYPE eventType, Component sender, object Params = null)
    {
        if (currentBoat < 2)
        {
            currentBoat++;
        }
        //sets prev boat to inactive
        BoatSelection[currentBoat - 1].SetActive(false);
        SetBoat(currentBoat);
    }

    private void SetBoat(int currentBoatIndex)
    {
        //gets slider from UI manager
        DurabilitySlider = GetComponent<UIManager>().durabiltySlider;
        //sets new boat to active
        BoatSelection[currentBoatIndex].SetActive(true);
        //sets the boats audio manager to the main audio manager
        BoatSelection[currentBoatIndex].GetComponent<BoatController>().audioManager = audioManager;
        //sets the durability slider to show the new boats durability
        BoatSelection[currentBoatIndex].GetComponent<Boat>().durabiltySlider = DurabilitySlider;

        //follow the new boat
        GetComponent<CineMachineSwitcher>().mainCam.Follow = BoatSelection[currentBoat].transform;
    }
}
