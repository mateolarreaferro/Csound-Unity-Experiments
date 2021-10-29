using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsoundPVSBlurSender : MonoBehaviour
{
    public CsoundUnity csound;
    public Transform sphere;
    public float lastPosY, currentPosY, amountMovedY;
    public float modulateBlur;
    public float recoveryRate;
    public float normalizedX;
    public float normalizedY;

    // Update is called once per frame
    void Update()
    {
        currentPosY = sphere.position.y;

        normalizedX = Mathf.InverseLerp(-9.03f, 9.03f, sphere.position.x);
        normalizedY = Mathf.InverseLerp(-6, 6f*4,Mathf.Abs( sphere.position.y));


        csound.SetChannel("blurTime", normalizedY * 3);
        csound.SetChannel("blurRate", normalizedX * 3);
        csound.SetChannel("speed", normalizedX + 0.2f);
        csound.SetChannel("mix", 0);
    }
}
