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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Collision Detected!");


            csoundUnity.SetChannel("freq", Random.Range(200f, 1000f));
            csoundUnity.SetChannel("feedback", Random.Range(0.80000f, 0.987000f));
            csoundUnity.SetChannel("tapl", Random.Range(0.1f, 0.9f));
            csoundUnity.SetChannel("tapm", Random.Range(0.1f, 0.9f));
            csoundUnity.SetChannel("tapr", Random.Range(0.1f, 0.9f));


            csoundUnity.SendScoreEvent("i 1000 0.0 10.9");
        }
    }

}
