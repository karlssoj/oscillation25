using Unity.VisualScripting;
using UnityEngine;

public class TankControler : MonoBehaviour
{
    public float Speed; // Hastighet för framåt/runtåt rörelse
    public float TurnSpeed; // Hastighet för rotation

    Vector3 Move; // Vektor för rörelse
    Vector3 Turn; // Vektor för rotation

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Move = new Vector3(0, 0, Speed);
        Turn = new Vector3(0, TurnSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardControl();
    }

    void KeyboardControl()
    {
        // Kontrollera uppåtpil för att röra sig framåt
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            transform.Translate(Move);
        }
        // Kontrollera nedåtpil för att röra sig bakåt
        else if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            transform.Translate(-Move);
        }
        // Kontrollera vänsterpil för att rotera motsols
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            transform.Rotate(-Turn);
        }
        // Kontrollera högerpil för att rotera medsols
        else if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            transform.Rotate(Turn);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Förstör "Food"-objekt vid kollision
        if (collision.gameObject.name == "Food")
        {
            Destroy(collision.gameObject);
        }
        
        // Visa meddelande vid kollision med "Goal"
        if(collision.gameObject.name == "Goal")
        {
            Debug.Log("Mission Completed!!!!");
        }
    }
}
