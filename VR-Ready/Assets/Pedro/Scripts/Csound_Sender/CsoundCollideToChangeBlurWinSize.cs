using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsoundCollideToChangeBlurWinSize : MonoBehaviour
{
    public CsoundUnity csound;
    public int whichTable;

    private void OnCollisionEnter(Collision collision)
    {
        csound.SetChannel("att_table", whichTable);
    }
}
