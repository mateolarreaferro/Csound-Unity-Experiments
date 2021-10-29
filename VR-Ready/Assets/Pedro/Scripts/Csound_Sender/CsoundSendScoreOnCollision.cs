using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsoundSendScoreOnCollision : MonoBehaviour
{

    // Declaring CsoundUnity variable to be set in the inspector
    public CsoundUnity csound;

    // Called when this rigdbody collides with another
    private void OnCollisionEnter(Collision collision)
    {
        // Sends a Csound Score even for instrument 1
        csound.SendScoreEvent("i 1 0 0.3");
    }
}
