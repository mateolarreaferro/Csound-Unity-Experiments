using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsoundObjectRotationSpeed : MonoBehaviour
{
    [Header("CSOUND")]
    [SerializeField] private CsoundUnity csound;
    [SerializeField] private ChannelRotationSpeedData[] channelData;

    [Header("VELOCITY")]
    public float maxRotationSpeedValue;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private bool debugRotationSpeed = false;

    private float rotationSpeed;
    private Vector3 previousRotation;

    // Start is called before the first frame update
    void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        if (csound == null)
            csound = GetComponent<CsoundUnity>();

        rb.maxAngularVelocity = maxRotationSpeedValue;
    }

    // Update is called once per frame
    void Update()
    {
        rotationSpeed = rb.angularVelocity.magnitude;

        foreach(ChannelRotationSpeedData data in channelData)
        {
            float value =
                Mathf.Clamp(ScaleFloat(0, maxRotationSpeedValue, data.minValue, data.maxValue, rb.angularVelocity.magnitude), data.minValue, data.maxValue);

            csound.SetChannel(data.channelName, value);
        }

        if (debugRotationSpeed)
            print(rotationSpeed);
    }

    private float ScaleFloat(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue)
    {
        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);
    }
}

[System.Serializable]
public class ChannelRotationSpeedData
{
    public string channelName;
    public float minValue, maxValue;
}
