using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsoundCollisionVelocityToPitch1 : MonoBehaviour
{
    public GameObject sphere;
    public float velocity;
    private Vector3 newPosition, oldPosition;
    public CsoundUnity csound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        newPosition = sphere.transform.position;

        velocity = Vector3.Distance(newPosition, oldPosition);

        csound.SetChannel("freq", velocity);

        oldPosition = sphere.transform.position;


    }

    private void OnCollisionEnter(Collision collision)
    {


        csound.SendScoreEvent("i1 0 0.5");
            
    }
}
