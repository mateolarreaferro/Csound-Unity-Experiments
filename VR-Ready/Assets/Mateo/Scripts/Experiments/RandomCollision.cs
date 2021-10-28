using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCollision : MonoBehaviour
{
    CsoundUnity csoundUnity;
    // Start is called before the first frame update
    void Start()
    {
        csoundUnity = GetComponent<CsoundUnity>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        float vel = collision.relativeVelocity.magnitude;
        Debug.Log(vel);

        csoundUnity.SetChannel("freq", Map(vel, 0.1f, 20f, 1f, 4000f)); 
        csoundUnity.SetChannel("feedback", Map(vel, 0.1f, 20f, 0.8f, 0.98f));
        csoundUnity.SetChannel("tapl", Map(vel, 0.1f, 20f, 0.1f, 0.9f));
        csoundUnity.SetChannel("tapm", Map(vel, 0.1f, 20f, 0.1f, 0.9f));
        csoundUnity.SetChannel("tapr", Map(vel, 0.1f, 20f, 0.1f, 0.9f));


        csoundUnity.SendScoreEvent("i 1000 0.0 10.9");

    }

    // Map Function
    float Map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }


}
