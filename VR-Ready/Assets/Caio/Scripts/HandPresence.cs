using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    private InputDevice targetDevice;

    public GameObject handModelPrefab;
    private GameObject spawnedHandModel;
    private Animator handAnimator;

    //Error safeguard
    private bool noController = false;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if(devices.Count > 0)
        {
            targetDevice = devices[0];
            spawnedHandModel = Instantiate(handModelPrefab, transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }
        else
        {
            Debug.Log("No controller device detected");
            noController = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (noController) { return; }
        UpdateHandAnimation();
    }

    private void UpdateHandAnimation()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
            handAnimator.SetFloat("trigger", triggerValue);
        else
            handAnimator.SetFloat("trigger", 0);

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            handAnimator.SetFloat("grip", gripValue);
        else
            handAnimator.SetFloat("grip", 0);
    }
}
