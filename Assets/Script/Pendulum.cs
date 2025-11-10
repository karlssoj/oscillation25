using System;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    float G = 9.82f;
    public GameObject Pivot;
    public GameObject Bob;

    public float Damping;

    float RotationSpeed = 0;

    float r;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        r = Vector3.Distance(Pivot.transform.position, Bob.transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float Angle = transform.eulerAngles.z;
        float AngularAcceleration = -G * Mathf.Sin(Angle * Mathf.Deg2Rad) / r;

        RotationSpeed += AngularAcceleration * Mathf.Rad2Deg * Time.deltaTime;
        RotationSpeed *= Damping;

        transform.Rotate(0, 0, RotationSpeed * Time.deltaTime);
    }
}
