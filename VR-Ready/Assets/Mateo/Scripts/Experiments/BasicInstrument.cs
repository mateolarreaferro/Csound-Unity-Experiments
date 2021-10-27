using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInstrument : MonoBehaviour
{
    CsoundUnity csoundUnity;

    //Distance Calculations
    [SerializeField] Transform[] _ports;
    float[] _distances = new float[4]; //store distances of cube and ports (y and z)
    float destructionDistance = 50f;

    // Start is called before the first frame update
    void Start()
    {
        csoundUnity = GetComponent<CsoundUnity>();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < _ports.Length; i++)
        {

            _distances[i] = Vector3.Distance(_ports[i].position, transform.position);
            Debug.Log(_distances[i]);

            if (_distances[i] > destructionDistance)
            {
                Destroy(this);
            }
        }

    }


    private void OnCollisionEnter(Collision collision)
    {


        float vel = collision.relativeVelocity.magnitude;


        // Send to Csound
        csoundUnity.SendScoreEvent("i 1000 0.1 0.5");
        csoundUnity.SetChannel("freq", Map(vel, 0.1f, 20f, 100, 6000f));
        csoundUnity.SetChannel("tapl", Map(_distances[3], -9f, 9f, 0.1f, 1f));
        csoundUnity.SetChannel("tapm", Map(_distances[2], -9f, 9f, 0.1f, 1f));
        csoundUnity.SetChannel("tapr", Map(_distances[1], -9f, 9f, 0.1f, 1f));
        csoundUnity.SetChannel("feedback", Map(_distances[0], -9f, 9f, 0.1f, 0.6f));



    }

    // Map Function
    float Map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }


   

    }

