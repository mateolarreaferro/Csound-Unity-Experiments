using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ControllerInputValues : MonoBehaviour
{
    private InputDevice rightHand;
    private InputDevice leftHand;

    public float leftTriggerValue;
    public float leftGripValue;
    public float rightTriggerValue;
    public float rightGripValue;

    // Start is called before the first frame update
    void Awake()
    {
        GetRightHandController();
    }

    void GetRightHandController()
    {
        var rightHandControllers = new List<InputDevice>();
        var rightHandCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.HeldInHand;
        InputDevices.GetDevicesWithCharacteristics(rightHandCharacteristics, rightHandControllers);

        if (rightHandControllers.Count > 0)
            rightHand = rightHandControllers[0];
        else
            Debug.Log("No right hand controller detected");
    }

    private void Update()
    {
        UpdateRightHandInputValues();
    }

    private void UpdateRightHandInputValues()
    {
        if (rightHand.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
            rightTriggerValue = triggerValue;
        else
            rightTriggerValue = 0;

        if (rightHand.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            rightGripValue = gripValue;
        else
            rightGripValue = 0;
    }
}
