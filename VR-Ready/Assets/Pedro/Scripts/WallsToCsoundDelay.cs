using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsToCsoundDelay : MonoBehaviour
{
    public CsoundUnity csound;
    public float normalizedWallPos;

    // Update is called once per frame
    void Update()
    {
        normalizedWallPos = Mathf.InverseLerp(4, 7, Mathf.Abs(transform.position.x))*0.6f + 0.2f;
        csound.SetChannel("feedback", normalizedWallPos*0.3f+0.5f);
        csound.SetChannel("tapl", normalizedWallPos);
        csound.SetChannel("tapr", normalizedWallPos);
        csound.SetChannel("tapm", normalizedWallPos);




    }
}
