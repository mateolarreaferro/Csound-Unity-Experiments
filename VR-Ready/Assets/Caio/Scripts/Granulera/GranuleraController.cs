using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranuleraController : MonoBehaviour
{
    private CsoundUnity csound;
    private GetControllerButtonValues leftInput;
    private GetControllerButtonValues rightInput;
    private int triggerToggle = 1;

    private int waveformSelection = 0;

    private void Awake()
    {
        leftInput = GameObject.Find("LeftHand Controller").GetComponent<GetControllerButtonValues>();
        rightInput = GameObject.Find("RightHand Controller").GetComponent<GetControllerButtonValues>();
    }
    // Start is called before the first frame update
    void Start()
    {
        csound = GetComponent<CsoundUnity>();
    }

    // Update is called once per frame
    void Update()
    {
        csound.SetChannel("FMAmp", rightInput.gripValue);
        csound.SetChannel("RMAmp", rightInput.triggerValue);

        csound.SetChannel("PitchVariation", leftInput.gripValue * 50);
        csound.SetChannel("ReverbMix", Mathf.Clamp01(0.15f + leftInput.triggerValue));
        csound.SetChannel("DelaySend", Mathf.Clamp01(0.15f + leftInput.triggerValue));
    }

    public void StartAndStop()
    {
        triggerToggle = 1 - triggerToggle;
        csound.SetChannel("OnOff", triggerToggle);
    }

    public void CycleWaveform()
    {
        waveformSelection++;
        if (waveformSelection > 5)
            waveformSelection = 1;

        csound.SetChannel("WaveformSelection1", waveformSelection);
        csound.SetChannel("WaveformSelection2", waveformSelection);
        csound.SetChannel("WaveformSelection3", waveformSelection);
    }
}
