using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsoundToggleTrigger : MonoBehaviour
{
    public CsoundUnity csound;
    public string triggerChannelName;
    private int triggerValue = 0;

    public void Trigger()
    {
        triggerValue = 1 - triggerValue;
        csound.SetChannel(triggerChannelName, triggerValue);
    }
}
