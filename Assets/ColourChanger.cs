using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    public MeshRenderer Mesh;
    Color ShallowStartColour = new Color(0.081f, 0.281f, 0.459f, 0.808f);
    Color DeepStartColour = new Color(0.113f, 0.376f, 0.047f, 0.800f);

    Color ShallowEndColour = new Color(0.118f, 0.925f, 0.840f, 0.808f);
    Color DeepEndColour = new Color(0.087f, 0.452f, 0.594f, 0.694f);

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Mesh.material.SetColor("ShallowWater", ShallowStartColour);
        Mesh.material.SetColor("DeepWater", DeepStartColour);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Mesh.material.SetColor("ShallowWater", ShallowEndColour);
            Mesh.material.SetColor("DeepWater", DeepEndColour);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            print("Shallow: " + Mesh.material.GetColor("ShallowWater"));
            print("Deep: " + Mesh.material.GetColor("DeepWater"));
        }
    }

}
