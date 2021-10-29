using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedToFreq_PosToPan : MonoBehaviour
{
    public GameObject sphere;
    public float velocity;
    private Vector3 newPosition, oldPosition;
    public CsoundUnity csound;


    // Update is called once per frame
    void Update()
    {

        newPosition = sphere.transform.position;


        velocity = Vector3.Distance(newPosition, oldPosition);

        csound.SetChannel("freq", velocity);
        csound.SetChannel("pan", (transform.position.x/20)+ 0.5f);


        oldPosition = sphere.transform.position;


    }

    private void OnCollisionEnter(Collision collision)
    {


        csound.SendScoreEvent("i1 0 0.5");
            
    }
}
