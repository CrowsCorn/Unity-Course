using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource Audio;
    [SerializeField] float Thrust = 0.0f;
    [SerializeField] float LeftRotate = 0.0f;
    [SerializeField] float RightRotate = 0.0f;
    [SerializeField] AudioClip Thruster;
    [SerializeField] ParticleSystem MainThruster;
    [SerializeField] ParticleSystem LeftSideThruster; 
    [SerializeField] ParticleSystem RightSideThruster; 



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Audio = GetComponent<AudioSource>();
    }
    
  

    // Update is called once per frame
    void Update()
    {
        spaceinput();
        rotation();
    }

    void spaceinput()
    {
        Rocket();
    }

    void Rocket()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * Thrust * Time.deltaTime);
            if (!Audio.isPlaying)
            {
                Audio.PlayOneShot(Thruster);
            }
            if (!MainThruster.isPlaying)
            {
                MainThruster.Play();
            }
        }
        else
        {
            Audio.Stop();
            MainThruster.Stop();
        }
    }

    void rotation()
    {
        if(Input.GetKey(KeyCode.D))
        {
            TurnRight();
        }
        else if(Input.GetKey(KeyCode.A))
        {
            TurnLeft();
        }
        else
    {
        LeftSideThruster.Stop();
        RightSideThruster.Stop();
    }
    }

    void TurnLeft()
    {
        LeftSideThruster.Stop();
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * LeftRotate * Time.deltaTime);
        rb.freezeRotation = false;
        if (!RightSideThruster.isPlaying)
        {
            RightSideThruster.Play();
        }
    }

    void TurnRight()
    {
        RightSideThruster.Stop();
        rb.freezeRotation = true;
        transform.Rotate(Vector3.back * RightRotate * Time.deltaTime);
        rb.freezeRotation = false;
        if (!LeftSideThruster.isPlaying)
        {
            LeftSideThruster.Play();
        }
    }
}   


