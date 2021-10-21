using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
    [SerializeField] GameObject _object;

    [Range(0.005f, 1f)]
    [SerializeField] float rotationSpeed;

    Vector3 skyMovement = new Vector3(0, 90, 0);


    // Update is called once per frame
    void Update()
    {
        _object.transform.Rotate(skyMovement * Time.deltaTime * rotationSpeed);
        

    }
}
