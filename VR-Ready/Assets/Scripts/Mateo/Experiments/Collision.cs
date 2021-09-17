using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    CsoundUnity csoundUnity;
    // Start is called before the first frame update
    void Start()
    {
        csoundUnity = GetComponent<CsoundUnity>();
    }

    private void OnTriggerEnter(Collider other)
    {
      
            Debug.Log("Collision detected!");
            csoundUnity.SetChannel("freq", Random.Range(300f, 1000f));
            csoundUnity.SendScoreEvent("i\"PlaySound\", 0 .5");
       
    }


}
