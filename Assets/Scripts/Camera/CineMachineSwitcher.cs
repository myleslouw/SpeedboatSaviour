using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineMachineSwitcher : MonoBehaviour
{
    Animator animator;
    public CinemachineVirtualCamera mainCam, closeUpCam;

    //higher priority cam will be show
    private int mainPriority = 10, offCam = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            mainCam.Priority = mainPriority;
            closeUpCam.Priority = offCam;
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            mainCam.Priority = offCam;
            closeUpCam.Priority = mainPriority;
        }
    }
}
