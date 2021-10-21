using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensor : MonoBehaviour {

    //VARIABLES

CsoundUnity csoundUnity;

//Distance Calculations for Port
[SerializeField] Transform _ports; //port a and b
public double _distances; //store distances of cube and ports (y and z)
[SerializeField] double _limit = 1.0f;

//Opening gate in Csound for drone
public bool inPort;



//play with materials
[SerializeField] Material shaderMaterial = null;


    //FUNCTIONS

    // Start is called before the first frame update
    void Start()
    {
        //Get Components

        csoundUnity = GetComponent<CsoundUnity>();

        //Port

        inPort = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!inPort)
        {

            if (_distances > _limit)
            {
                _distances = _limit;
            }

            else
            {

                //Get Distance Value
                _distances = Vector3.Distance(_ports.position, transform.position);


                //Open Gate in Csound

                csoundUnity.SetChannel("gate", 1);
                csoundUnity.SetChannel("frequency", (float) Map(_distances, 0.1f, 0.6f, 100f, 1000f));
                csoundUnity.SetChannel("amplitude", (float) _distances);



                //Play with material
                shaderMaterial.SetFloat("_Fresnel", (float)Map(_distances, 0.1f, 0.6f, 10f, 1f));
                shaderMaterial.SetFloat("_Noise", (float)Map(_distances, 0.1f, 0.6f, 50f, 1f));

                //shaderMaterial.SetColor("_Color", Color.blue);
                //shaderMaterial.SetColor("_Base", Color.blue);
            }
        }

    }

    // Map Function
    double Map(double x, double in_min, double in_max, double out_min, double out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }

    // Port
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sensor"))
        {
            inPort = true;

            csoundUnity.SetChannel("gate", 0);

        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Sensor"))
        {
            inPort = false;
        }

    }



}
