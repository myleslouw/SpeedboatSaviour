using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLerp : MonoBehaviour
{
    //adjust this to change speed
    float speed = 2;
    float height = 0.08f;
    float yRotate = 0;

    void Start()
    {
    }

    void Update()
    {
        transform.position = new Vector3(-1.4f, Mathf.Sin(-Time.time * speed) * height + 1.39f, -2.2f);
        transform.Rotate(0, 0.1f, 0);
    }
}
