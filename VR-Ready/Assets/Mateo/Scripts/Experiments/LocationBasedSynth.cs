using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationBasedSynth : MonoBehaviour
{
    CsoundUnity csoundUnity;

    [SerializeField] Transform[] _points;
    [SerializeField] double[] _distances;

    // Start is called before the first frame update
    void Start()
    {
        csoundUnity = GetComponent<CsoundUnity>();
    }

    private void Update()
    {
        for (int i = 0; i < _distances.Length; i++)
        {
            _distances[i] = Vector3.Distance(_points[i].position, transform.position);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            Debug.Log("Collision Detected");

            PlayBeast();

           
        }
        
    }


    void PlayBeast()
    {
        //Detection

        Debug.Log("Instrument 1000 Ready to Play");

        //Set Channels
        //TODO Optimize this section

        csoundUnity.SetChannel("datrigger", 1); //cambiar para abrir gate

        csoundUnity.SetChannel("numInstrs", (float) Map(_distances[0], 1.0, 20f, 10.0, 200.0f));

        csoundUnity.SetChannel("1frqLow", (float) Map(_distances[0], 1.0, 20f, 40.0, 4000.0f));

        csoundUnity.SetChannel("1frqHi", (float) Map(_distances[0], 1.0, 20f, 40.0, 4000.0f));

        csoundUnity.SetChannel("2frqLow", (float)Map(_distances[0], 1.0, 20f, 650.0, 2750.0f));

        csoundUnity.SetChannel("2frqHi", (float)Map(_distances[0], 1.0, 20f, 800.0, 4000.0f));

        csoundUnity.SetChannel("1durLow", (float)Map(_distances[0], 1.0, 20f, 0.8, 2.0f));

        csoundUnity.SetChannel("1durHi", (float)Map(_distances[0], 1.0, 20f, 1f, 8.0f));

        csoundUnity.SetChannel("2durLow", (float)Map(_distances[0], 1.0, 20f, 0.3f, 1.0f));

        csoundUnity.SetChannel("2durHi", (float)Map(_distances[0], 1.0, 20f, 0.9f, 4000.0f));

        csoundUnity.SetChannel("3frqLow", (float)Map(_distances[0], 1.0, 20f, 40f, 4000.0f));

        csoundUnity.SetChannel("3fqrHi", (float)Map(_distances[0], 1.0, 20f, 80f, 4000.0f));

        csoundUnity.SetChannel("4frqLow", (float)Map(_distances[0], 1.0, 20f, 1200f, 4000.0f));

        csoundUnity.SetChannel("4frqHi", (float)Map(_distances[0], 1.0, 20f, 1490f, 200.0f));

        csoundUnity.SetChannel("3durLow", (float)Map(_distances[0], 1.0, 20f, 0.4f, 4000.0f));

        csoundUnity.SetChannel("3durHi", (float)Map(_distances[0], 1.0, 20f, 0.4f, 4000.0f));

        csoundUnity.SetChannel("4durLow", (float)Map(_distances[0], 1.0, 20f, 0.3f, 4000.0f));

        csoundUnity.SetChannel("4durHi", (float)Map(_distances[0], 1.0, 20f, 40.0, 4000.0f));

        csoundUnity.SetChannel("transpose", (float)Map(_distances[0], 1.0, 20f, 40.0, 4000.0f));

        csoundUnity.SetChannel("pan", (float)Map(_distances[0], 1.0, 20f, 40.0, 4000.0f));

        csoundUnity.SetChannel("volume", (float) Map(_distances[0], 1.0, 20f, 0.0f, 1.0f));

        csoundUnity.SetChannel("chorus", (float)Map(_distances[0], 1.0, 20f, 0f, 1.0f));

        csoundUnity.SetChannel("reverb", (float)Map(_distances[0], 1.0, 20f, 0f, 1.0f));

        //csoundUnity.SetChannel("datrigger", 0);

        //Send Score Event

        //// in csd file event "i", 1000, 0, chnget:i("maxDur")
        //csoundUnity.SendScoreEvent("i 1000 0.25 14.0"); //Didn't use chnget part to avoid confusion



    }

    double Map(double x, double in_min, double in_max, double out_min, double out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }






}


