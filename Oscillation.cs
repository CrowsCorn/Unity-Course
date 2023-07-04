using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillation : MonoBehaviour
{
    Vector3 StartingPos;
    [SerializeField]Vector3 MovementVector;
    [SerializeField] [Range(0,1)] float MovementFactor;
    [SerializeField] float period = 2f;
    
    void Start()
    {
        StartingPos = transform.position;
    

    }

    void Update()
    {   
        if (period <= Mathf.Epsilon)
        {return;}
        float cycles = Time.time / period; //Grows over time forever
        const float tau = Mathf.PI * 2; // tau is 2PI
        float SinWave = Mathf.Sin(cycles * tau);
        //we use tau in order to occiliate the object along a sinwave
        //going along from -1 to 1

        MovementFactor = (SinWave + 1f) / 2f; //reajust the sinwave to 0 to 1

        Vector3 offset = MovementVector * MovementFactor;
        transform.position = StartingPos + offset;

    }
}
