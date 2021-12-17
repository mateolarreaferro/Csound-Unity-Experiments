using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torque : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 torqueVector;

    public void ApplyTorque()
    {
        rb.AddTorque(torqueVector);
    }
}
