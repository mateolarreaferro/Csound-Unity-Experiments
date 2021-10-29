using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScene : MonoBehaviour
{
    public ModeManager modeManager;
    public int whichMode;

    private void OnCollisionEnter(Collision collision)
    {
        modeManager.turnAllOffBut(whichMode);
    }
}
