using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranuleraTemplates : MonoBehaviour
{
    public enum GranuleraTemplate { template1 };

    private CsoundUnity csound;
    public GranuleraTemplate templateSelection;

    // Start is called before the first frame update
    void Awake()
    {
        csound = GetComponent<CsoundUnity>();
    }

    private void Start()
    {
        switch (templateSelection)
        {
            case GranuleraTemplate.template1:
                Template1();
                break;
        }
    }

    private void Template1()
    {
        csound.SetChannel("Oscillator1Volume", 1);
        csound.SetChannel("Oscillator1Semitone", 0);
        csound.SetChannel("Oscillator1Cents", 0);

        csound.SetChannel("Oscillator2Volume", 1);
        csound.SetChannel("Oscillator2Semitone", 2);
        csound.SetChannel("Oscillator2Cents", 0);

        csound.SetChannel("Oscillator3Volume", 1);
        csound.SetChannel("Oscillator3Semitone", 5);
        csound.SetChannel("Oscillator3Cents", 0);

        csound.SetChannel("GrainSpread", 0.5f);

        csound.SetChannel("GrainDuration", 0.35f);
        csound.SetChannel("DurationVariationRange", 0.152f);
        csound.SetChannel("DurationVariationRate", 3);
        csound.SetChannel("GrainDensity", 30);
        csound.SetChannel("DensityVariationRange", 18);
        csound.SetChannel("DensityVariationRate", 3.2f);

        csound.SetChannel("RMFreq", 612);
        csound.SetChannel("FMFreq", 2160);
        csound.SetChannel("GlobalVolume", 0.15f);

        csound.SetChannel("AmpAttack", 3.5f);
        csound.SetChannel("AmpDecay", 0.1f);
        csound.SetChannel("AmpSustain", 1f);
        csound.SetChannel("AmpRelease", 3.5f);

        csound.SetChannel("ReverbSend", 1);
        csound.SetChannel("ReverbMix", 0.5f);
        csound.SetChannel("ReverbSize", 0.9f);

        csound.SetChannel("DelayBypass", 1);
        csound.SetChannel("DelaySend", 0.45f);
        csound.SetChannel("DelayMix", 1);
        csound.SetChannel("DelayTimeLeft", 0.5f);
        csound.SetChannel("DelayTimeRight", 0.8f);
        csound.SetChannel("DelayFeedback", 0.75f);
    }
}
