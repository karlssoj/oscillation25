using System;
using UnityEngine;

public class SineCurve : MonoBehaviour
{
    Vector3 position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        position = transform.position;      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        position.y = Mathf.Sin(Time.time + position.x);
        transform.position = position;
    }
}
