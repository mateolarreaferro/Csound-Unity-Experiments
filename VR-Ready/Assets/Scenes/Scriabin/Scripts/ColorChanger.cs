using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorChanger : MonoBehaviour
{
    public Material newMaterial;
    public UnityEvent triggerEvent;

    private void OnTriggerEnter(Collider other)
    {
        // change brush tip
        other.GetComponent<Renderer>().material = newMaterial;

        // change line material
        other.SendMessageUpwards("SetLineMaterial", newMaterial, SendMessageOptions.DontRequireReceiver);

        // send unity event
        triggerEvent?.Invoke();
    }
}
