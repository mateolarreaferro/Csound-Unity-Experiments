using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Size Changer

public class SizeChanger : MonoBehaviour
{
    // Seconds
    [SerializeField] float scalingDuration = 5f;

    // Target Scale
    [SerializeField] Vector3 targetScale = Vector3.one * .1f;

    // Starting Scale
    Vector3 startingScale;

    // t for linear interpolation
    float interpolant = 0;


    [SerializeField] bool Scaling;

    void Start()
    {
        
        startingScale = this.transform.localScale;

        interpolant = 0;
    }

    void Update()
    {
        ScaleDown();

    }

    void ScaleDown()
    {
        if (Scaling)
        {

            //time it takes from 0-1
            interpolant += Time.deltaTime / scalingDuration;

            // Lerp from startScale to targetScale (interpolant -> 0-1)
            Vector3 newScale = Vector3.Lerp(startingScale, targetScale, interpolant);

            transform.localScale = newScale;
            

            //optimization
            if (interpolant > 1) {

                Scaling = false;
            
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Table"))
        {
            Debug.Log("Detected");
            Scaling = true;
        }
        



    }



}
