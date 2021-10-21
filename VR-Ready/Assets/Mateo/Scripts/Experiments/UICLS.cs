using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICLS : MonoBehaviour
{
    [SerializeField] GameObject _sphere;
    [Range(0.1f, 5)]
    [SerializeField] float rotationSpeed;
    [Range(-1, 1)]
    [SerializeField] float rotationDirection;
    [SerializeField] bool isRotating;



    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            _sphere.transform.Rotate(new Vector3(0, rotationDirection * 90, 0) * rotationSpeed * Time.deltaTime);
        }
        
    }

  
}
