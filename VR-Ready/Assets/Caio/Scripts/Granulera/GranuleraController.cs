using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranuleraController : MonoBehaviour
{
    private CsoundUnity csound;
    public ControllerInputValues input;

    private bool isPlaying = false;
    private int triggerToggle = 0;

    // Start is called before the first frame update
    void Start()
    {
        csound = GetComponent<CsoundUnity>();
    }

    // Update is called once per frame
    void Update()
    {
        StartAndStopOnInput();

        csound.SetChannel("FMAmp", input.rightGripValue);
        csound.SetChannel("RMAmp", input.rightTriggerValue);

        csound.SetChannel("PitchVariation", input.leftGripValue * 50);
        csound.SetChannel("ReverbMix", Mathf.Clamp01(0.15f + input.leftTriggerValue));
        csound.SetChannel("DelaySend", Mathf.Clamp01(0.15f + input.leftTriggerValue));
    }

    void StartAndStopOnInput()
    {
        triggerToggle = 1 - triggerToggle;

        if (input.rightPrimaryValue == true && !isPlaying)
        {
            csound.SetChannel("OnOff", triggerToggle);
            isPlaying = true;
        }
        else if(input.rightSecondaryValue == true && isPlaying)
        {
            csound.SetChannel("OnOff", triggerToggle);
            isPlaying = false;
        }
    }

    //public void StartStopTest()
    //{
    //    triggerToggle = 1 - triggerToggle;

    //    if (!isPlaying)
    //    {
    //        csound.SetChannel("OnOff", triggerToggle);
    //        isPlaying = true;
    //        print("START");
    //    }
    //    else
    //    {
    //        csound.SetChannel("OnOff", triggerToggle);
    //        isPlaying = false;
    //        print("STOP");
    //    }
    //}
}
