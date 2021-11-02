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
        //OSCILLATORS
        csound.SetChannel("WaveformSelection1", 1);
        csound.SetChannel("Oscillator1Volume", 1);
        csound.SetChannel("Oscillator1Semitone", 0);
        csound.SetChannel("Oscillator1Cents", 0);

        csound.SetChannel("WaveformSelection2", 1);
        csound.SetChannel("Oscillator2Volume", 1);
        csound.SetChannel("Oscillator2Semitone", 2);
        csound.SetChannel("Oscillator2Cents", 0);

        csound.SetChannel("WaveformSelection3", 1);
        csound.SetChannel("Oscillator3Volume", 1);
        csound.SetChannel("Oscillator3Semitone", 5);
        csound.SetChannel("Oscillator3Cents", 0);

        //GRANULATION
        csound.SetChannel("GrainSpread", 0.5f);

        csound.SetChannel("WindowingSelection", 2);
        csound.SetChannel("FrequencyVariationRange", 0);
        csound.SetChannel("FrequencyVariationRate", 0);
        csound.SetChannel("PitchVariation", 0);
        csound.SetChannel("GrainDuration", 0.35f);
        csound.SetChannel("DurationVariationRange", 0.152f);
        csound.SetChannel("DurationVariationRate", 3);
        csound.SetChannel("GrainDensity", 25);
        csound.SetChannel("DensityVariationRange", 18);
        csound.SetChannel("DensityVariationRate", 3.2f);
        csound.SetChannel("PhaseVariation", 1);

        //FILTER
        csound.SetChannel("FilterNoteTrack", 1);
        csound.SetChannel("FilterSelection", 1);
        csound.SetChannel("FilterFreq", 0.7f);
        csound.SetChannel("FilterRange", 0.0001f);
        csound.SetChannel("FilterReson", 1);
        csound.SetChannel("FilterBW", 1000);
        csound.SetChannel("FilterAttack", 0.01f);
        csound.SetChannel("FilterDecay", 1);
        csound.SetChannel("FilterSustain", 1);
        csound.SetChannel("FilterRelease", 0.1f);

        //LFOs
        //To Do

        //MODULATION
        csound.SetChannel("RMFreq", 612);
        csound.SetChannel("FMFreq", 2160);

        //GLOBALS
        csound.SetChannel("GlobalVolume", 0.1f);
        csound.SetChannel("GlobalPan", 0.5f);
        csound.SetChannel("GlobalTuning", 0.1f);

        //AMP ENVELOPE
        csound.SetChannel("AmpEnvelopeToggle", 0);
        csound.SetChannel("AmpAttack", 3.5f);
        csound.SetChannel("AmpDecay", 0.1f);
        csound.SetChannel("AmpSustain", 1f);
        csound.SetChannel("AmpRelease", 3.5f);

        //REVERB
        csound.SetChannel("ReverbBypass", 1);
        csound.SetChannel("ReverbSend", 1);
        csound.SetChannel("ReverbMix", 0.5f);
        csound.SetChannel("ReverbSize", 0.9f);

        //DELAY
        csound.SetChannel("DelayBypass", 1);
        csound.SetChannel("DelaySend", 0.45f);
        csound.SetChannel("DelayMix", 1);
        csound.SetChannel("DelayTimeLeft", 0.3f);
        csound.SetChannel("DelayTimeRight", 0.6f);
        csound.SetChannel("DelayFeedback", 0.75f);
    }
}
