using System;
using UnityEngine;

public class WingSwing : MonoBehaviour
{
    //Amplitud för vingrörelsen
    public float Amplitude;
    //Frekvens för vingrörelsen
    public float Frequency;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Beräknar rotationsvinkeln runt z-azeln för vingen enligt formeln för enkel harmonisk svängningsrörelse
        float Rotation = Amplitude * Mathf.Sin(2 * Mathf.PI * Frequency * Time.time);
 
        //Ställer in z-rotationen enligt Rotation och bibehåller samma rotation runt x och y som tidigare
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Rotation);
    }
}
