using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    CsoundUnity csoundUnity;
    [SerializeField] Transform _sphere;
    [SerializeField] float distanceToSphere;

    // Start is called before the first frame update
    void Start()
    {
        csoundUnity = GetComponent<CsoundUnity>();
    }

    private void Update()
    {
        distanceToSphere = Vector3.Distance(_sphere.position, transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CLS"))
        {
            Debug.Log("Collision detected!");
            csoundUnity.SetChannel("freq", (float) Map(distanceToSphere, 0, 1.8, 400.0, 6000.0));
            csoundUnity.SetChannel("feedback", (float) Map(distanceToSphere, 0.5, 1.3, 0.8, 0.978));
            csoundUnity.SendScoreEvent("i 1000 0.0 10.9"); //remember format
        }
       
    }

    double Map(double x, double in_min, double in_max, double out_min, double out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }








}


