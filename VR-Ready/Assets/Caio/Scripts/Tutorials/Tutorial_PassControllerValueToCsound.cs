using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_PassControllerValueToCsound : MonoBehaviour
{
    private CsoundUnity csound;
    public GetControllerButtonValues rightHandInput;
    public GetControllerButtonValues leftHandInput;

    // Start is called before the first frame update
    void Start()
    {
        csound = GetComponent<CsoundUnity>();
    }

    // Update is called once per frame
    void Update()
    {
        csound.SetChannel("PitchVariation", rightHandInput.triggerValue * 50);
        csound.SetChannel("FMAmp", leftHandInput.gripValue);
    }
}
