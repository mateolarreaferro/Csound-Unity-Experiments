using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsoundToggleTrigger : MonoBehaviour
{
    public CsoundUnity csound;
    public string triggerChannelName;
    private int triggerValue = 0;

    private void OnTriggerEnter(Collider other)
    {
        triggerValue = 1 - triggerValue;
        csound.SetChannel(triggerChannelName, triggerValue);
        //csound.SendScoreEvent

        Debug.Log("TRIGGER ENTER: " + other.gameObject.name);
    }
}
