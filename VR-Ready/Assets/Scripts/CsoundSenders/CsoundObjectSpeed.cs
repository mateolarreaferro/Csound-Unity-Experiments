using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsoundObjectSpeed : MonoBehaviour
{
    public enum VelocityMethod { Rigidbody, Transform };

    [Header("CSOUND")]
    [SerializeField] private CsoundUnity csound;
    [SerializeField] private ChannelSpeedData[] channelData;

    [Header("VELOCITY")]
    [SerializeField] private VelocityMethod velocityMethod = VelocityMethod.Rigidbody;
    public float maxVelocity;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private bool debugVelocity = false;

    private float velocity;
    private Vector3 previousPos;

    private void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        if (csound == null)
            csound = GetComponent<CsoundUnity>();
    }

    // Update is called once per frame
    void Update()
    {
        if (velocityMethod == VelocityMethod.Rigidbody)
        {
            velocity = rb.velocity.magnitude;
        }
        else if(velocityMethod == VelocityMethod.Transform)
        {
            velocity = ((transform.position - previousPos).magnitude) / Time.deltaTime;
            previousPos = transform.position;
        }

        foreach (ChannelSpeedData data in channelData)
        {
            float value =
                Mathf.Clamp(ScaleFloat.Scale(0, maxVelocity, data.minValue, data.maxValue, rb.velocity.magnitude), data.minValue, data.maxValue);

            csound.SetChannel(data.channelName, value);
        }

        if (debugVelocity)
            print(velocity);
    }
}

[System.Serializable]
public class ChannelSpeedData
{
    public string channelName;
    public float minValue, maxValue;
}