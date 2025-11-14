using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public GameObject Pivot;
    public GameObject Bob;

    public float Gravity = 9.82f;
    public float Damping = 0.998f;
    
    private Vector3 angularVelocity = Vector3.zero;
    float r;


    void Start()
    {
        r = Vector3.Distance(Pivot.transform.position, Bob.transform.position);
    }


    void FixedUpdate()
    {
        Vector3 PendulumArmDirectionDirection = (Bob.transform.position - Pivot.transform.position).normalized;
        
        // Beräkna rotationsaxel med kryssprodukt
        // Denna axel pekar vinkelrätt mot lutningsplanet
        Vector3 rotationAxis = Vector3.Cross(PendulumArmDirectionDirection, Vector3.down);
        
        // Beräkna vinkeln från vertikal
        float angleFromVertical = Vector3.Angle(PendulumArmDirectionDirection, Vector3.down) * Mathf.Deg2Rad;
        
        // Beräknar storleken på vinkelaccelerationen
        float accelerationMagnitude = (Gravity * Mathf.Sin(angleFromVertical))/r;
        
        // Multiplicerar storleken för vinkelaccelerationen med rotationsaxelns riktning (för att få rotationen åt rätt håll)
        Vector3 angularAcceleration = rotationAxis.normalized * accelerationMagnitude;
        
        // Uppdatera vinkelhastighet
        angularVelocity += angularAcceleration * Time.deltaTime;
        angularVelocity *= Damping;

        transform.Rotate(angularVelocity * Mathf.Rad2Deg * Time.deltaTime, Space.World);
    }
}
