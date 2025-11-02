using UnityEngine;

public class CosineCurve : MonoBehaviour
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
        position.y = Mathf.Cos(Time.time + position.x);
        transform.position = position;
    }
}
