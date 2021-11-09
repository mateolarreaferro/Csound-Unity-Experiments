using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranuleraChangeNote : MonoBehaviour
{
    private CsoundUnity csound;

    // Start is called before the first frame update
    void Start()
    {
        csound = GetComponent<CsoundUnity>();
    }

    public void PassMidiNote(float midiNote)
    {
        csound.SetChannel("MidiNote", midiNote);
    }
}
