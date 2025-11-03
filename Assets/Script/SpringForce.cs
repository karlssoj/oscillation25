using UnityEngine;

public class SpringForce : MonoBehaviour
{
    //Fjäderkonstanten för repet som kan definieras i inspektorn
    public float SpringConstant;

    //Rörliga delens ursprungsposition i Y-led
    float Y0;
    
    Rigidbody physics;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        physics = GetComponent<Rigidbody>();
        
        //Y0 är rörliga delens (plattformens och kolvens) urpsrungsposition i
        //Y-led
        Y0 = transform.position.y;   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Beräknar Y0 dvs. hur mycket rörliga delen i praktiken sjunkit ner
        //till följd av tyngdkraften i förhållande till ursprungspositionen
        float deltaY = Y0 - transform.position.y;

        //Beräknar fjäderkraften enligt formeln för Hooke's lag
        float SpringF = SpringConstant * deltaY;

        //Utsätter rörliga delen för fjäderkraften i Y-led
        physics.AddForce(new Vector3(0, SpringF, 0));
    }
}
