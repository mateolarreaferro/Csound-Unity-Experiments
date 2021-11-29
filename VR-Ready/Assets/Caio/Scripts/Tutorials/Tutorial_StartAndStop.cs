using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_StartAndStop : MonoBehaviour
{
    public CsoundUnity csound;

    public void Play()
    {
        csound.SetChannel("OnOff", 1);
    }

    public void Stop()
    {
        csound.SetChannel("OnOff", 0);
    }
}
