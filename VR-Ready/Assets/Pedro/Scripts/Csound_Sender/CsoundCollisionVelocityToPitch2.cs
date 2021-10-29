using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsoundCollisionVelocityToPitch2 : MonoBehaviour
{
    public GameObject sphere;
    public float freqRange;
    public float velocity;
    public float offset;
    private Vector3 newPosition, oldPosition;
    public CsoundUnity csound;



    // Update is called once per frame
    void Update()
    {

        newPosition = sphere.transform.position;


        velocity = Vector3.Distance(newPosition, oldPosition);

        csound.SetChannel("freq", (velocity * freqRange) + offset);


        oldPosition = sphere.transform.position;


    }

    private void OnCollisionEnter(Collision collision)
    {

        
        csound.SendScoreEvent("i1 0 0.5");

    }
}
