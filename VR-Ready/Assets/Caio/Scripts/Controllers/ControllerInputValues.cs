using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;

public class ControllerInputValues : MonoBehaviour
{
    private InputDevice rightHand;
    private InputDevice leftHand;

    [HideInInspector] public float leftTriggerValue;
    [HideInInspector] public float leftGripValue;
    [HideInInspector] public float rightTriggerValue;
    [HideInInspector] public float rightGripValue;

    [HideInInspector] public bool leftPrimaryValue;
    [HideInInspector] public bool leftSecondaryValue;
    [HideInInspector] public bool rightPrimaryValue;
    [HideInInspector] public bool rightSecondaryValue;


    //public UnityEvent leftPrimaryButtonEvent;
    //public UnityEvent leftSecondaryButtonEvent;

    //public UnityEvent rightPrimaryButtonEvent;
    //public UnityEvent rightSecondaryButtonEvent;

    // Start is called before the first frame update
    void Awake()
    {
        GetRightHandController();
        GetLeftHandController();
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

    void GetLeftHandController()
    {
        var leftHandControllers = new List<InputDevice>();
        var leftHandCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.HeldInHand;
        InputDevices.GetDevicesWithCharacteristics(leftHandCharacteristics, leftHandControllers);

        if (leftHandControllers.Count > 0)
            leftHand = leftHandControllers[0];
        else
            Debug.Log("No left hand controller detected");
    }

    private void Update()
    {
        UpdateRightHandInputValues();
        UpdateLeftHandInputValues();
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

        if (rightHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue))
            rightPrimaryValue = primaryButtonValue;
        else
            rightPrimaryValue = false;

        if (rightHand.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue))
            rightSecondaryValue = secondaryButtonValue;
        else
            rightSecondaryValue = false;
    }

    private void UpdateLeftHandInputValues()
    {
        if (leftHand.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
            leftTriggerValue = triggerValue;
        else
            leftTriggerValue = 0;

        if (leftHand.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            leftGripValue = gripValue;
        else
            leftGripValue = 0;

        if (leftHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue))
            leftPrimaryValue = primaryButtonValue;
        else
            leftPrimaryValue = false;

        if (leftHand.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue))
            leftSecondaryValue = secondaryButtonValue;
        else
            leftSecondaryValue = false;
    }
}
