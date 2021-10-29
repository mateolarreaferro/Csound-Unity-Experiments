using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranuleraController : MonoBehaviour
{
    private CsoundUnity csound;
    public ControllerInputValues input;
    private int triggerToggle = 0;

    // Start is called before the first frame update
    void Start()
    {
        csound = GetComponent<CsoundUnity>();
    }

    // Update is called once per frame
    void Update()
    {
        csound.SetChannel("FMAmp", input.rightGripValue);
        csound.SetChannel("RMAmp", input.rightTriggerValue);

        csound.SetChannel("PitchVariation", input.leftGripValue * 50);
        csound.SetChannel("ReverbMix", Mathf.Clamp01(0.15f + input.leftTriggerValue));
        csound.SetChannel("DelaySend", Mathf.Clamp01(0.15f + input.leftTriggerValue));
        csound.GetChannel()
    }

    public void StartAndStop()
    {
        triggerToggle = 1 - triggerToggle;
        csound.SetChannel("OnOff", triggerToggle);
    }
}
