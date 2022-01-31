using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformVelocity : MonoBehaviour
{
    [HideInInspector] public Vector3 velocityVector;
    private Vector3 previousPos;

    private void Update()
    {
        velocityVector = (transform.position - previousPos) / Time.deltaTime;
        previousPos = transform.position;
    }
}
