using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranuleraController : MonoBehaviour
{
    private CsoundUnity csound;
    public ControllerInputValues input;

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
    }
}
