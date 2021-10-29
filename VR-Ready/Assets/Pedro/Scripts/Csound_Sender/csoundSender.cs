using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csoundSender : MonoBehaviour
{
    public CsoundUnity csound;
    public float normalizedX, normalizedY;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        normalizedX = (transform.position.x + 5.59f) / 11.18f;
        normalizedY = (transform.position.y + 1.36f) / 4.51f;

        normalizedY = Mathf.Clamp(normalizedY, 0, 1);

        csound.SetChannel("normalizedX", normalizedX);
        csound.SetChannel("normalizedY", normalizedY);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SoundTrigger1"))
            csound.SendScoreEvent("i1 0 2 60");
        if (other.CompareTag("SoundTrigger2"))
            csound.SendScoreEvent("i1 0 2 64");
        if (other.CompareTag("SoundTrigger3"))
            csound.SendScoreEvent("i1 0 2 67");
    }
}
