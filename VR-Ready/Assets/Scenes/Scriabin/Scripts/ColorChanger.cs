using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorChanger : MonoBehaviour
{
    public Material newMaterial;
    private Material color;
    public UnityEvent triggerEvent;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("Pincel")) { return; }

        // get material
        color = gameObject.GetComponent<Renderer>().material;

        // change brush tip
        other.GetComponent<Renderer>().material = color;

        // change line material
        other.SendMessageUpwards("SetLineMaterial", color, SendMessageOptions.DontRequireReceiver);

        // send unity event
        triggerEvent?.Invoke();
    }
}
