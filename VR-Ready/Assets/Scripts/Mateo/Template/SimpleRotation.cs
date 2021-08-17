using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
    [SerializeField] GameObject _sun, _moon;

    [Range(0.005f, 1f)]
    [SerializeField] float rotationSpeed;

    Vector3 skyMovement = new Vector3(90, 90, 90);


    // Update is called once per frame
    void Update()
    {
        _sun.transform.Rotate(skyMovement * Time.deltaTime * rotationSpeed);
        _moon.transform.Rotate(skyMovement * Time.deltaTime * rotationSpeed);

    }
}
