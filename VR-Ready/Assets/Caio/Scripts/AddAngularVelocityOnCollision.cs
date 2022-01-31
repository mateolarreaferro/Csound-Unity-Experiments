using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAngularVelocityOnCollision : MonoBehaviour
{
    private TransformVelocity leftHand;
    private TransformVelocity rightHand;
    private Rigidbody rb;
    [SerializeField] private float TorqueResistance;

    public AudioSource debugAudio;

    private void Awake()
    {
        leftHand = GameObject.FindWithTag("LeftHand").GetComponent<TransformVelocity>();
        rightHand = GameObject.FindWithTag("RightHand").GetComponent<TransformVelocity>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LeftHand"))
        {
            rb.AddTorque(leftHand.velocityVector / TorqueResistance);
        }
        else if (collision.gameObject.CompareTag("RightHand"))
        {
            rb.AddTorque(rightHand.velocityVector / TorqueResistance);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LeftHand"))
        {
            rb.AddTorque(leftHand.velocityVector / TorqueResistance);
        }
        else if (other.gameObject.CompareTag("RightHand"))
        {
            rb.AddTorque(rightHand.velocityVector / TorqueResistance);
        }
    }
}
