using Unity.VisualScripting;
using UnityEngine;


public class Oscillator : MonoBehaviour
{
    public float Amplitude;
    public float Frequency;

    Vector3 position;

    float Speed = 0;
    float Rotation = 0;
    float OriginalY = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Slumpar ut en rotationsvinkel 0-360 som definierar fjärilens rotation runt y-axeln
        Rotation = Random.Range(0, 360);

        //Slumpar ut en hastighet som ska skuffa fjärilen framåt i "nosens" riktning
        Speed = Random.Range(0.04f, 0.09f);

        //Den ursprungliga y-koordinaten för fjärilen
        OriginalY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {   
        //Tillämpar formeln för enkel harmoniska svängningsrörelse för att definiera fjärilens y koordinat adderat med
        //fjärilens ursprungliga y-koordinat 
        float y = (Amplitude * Mathf.Sin(2 * Mathf.PI * Frequency * Time.time)) + OriginalY;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);

        //Roterar fjärjilen runt y-axeln enligt den slumpmässiga vinklen och skuffar den sedan rakt framåt
        //på z-axeln enligt speed.
        transform.eulerAngles = new Vector3(0, Rotation, 0);
        transform.Translate(0, 0, Speed); 
    }
}
    