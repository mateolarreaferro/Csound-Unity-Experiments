using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//TODO
//Make X and Z axis relative to rotation

public class CsoundSendValuesBasedOnHandPosition : MonoBehaviour
{
    public enum PositionReference { Absolute, Relative };

    [Header("DEBUGGIN")]
    public bool debug;
    public TextMeshProUGUI vectorDisplayText;
    [Space]
    [Header("VECTOR RANGES")]
    [SerializeField] private Vector3 vectorRanges;
    [SerializeField] private PositionReference setXPositionTo = PositionReference.Relative;
    [SerializeField] private PositionReference setYPositionTo = PositionReference.Absolute;
    [SerializeField] private PositionReference setZPositionTo = PositionReference.Relative;
    [SerializeField] private bool updatePositionOnStart = false;
    [Space]
    [Header("CSOUND CHANNELS")]
    [SerializeField] private CsoundUnity csound;
    [SerializeField] private CsoundChannelValuesBasedOnPosition[] csoundChannelsX;
    [SerializeField] private CsoundChannelValuesBasedOnPosition[] csoundChannelsY;
    [SerializeField] private CsoundChannelValuesBasedOnPosition[] csoundChannelsZ;

    //Position references
    private Vector3 startPos;
    private Vector3 relativePos;
    private bool updatePosition = false;

    private void Start()
    {
        if (updatePositionOnStart)
            updatePosition = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!updatePosition) { return; }

        CaculateRelativePos();
        SetCsoundValuesY();
        SetCsoundValuesX();
        SetCsoundValuesZ();

        if (debug)
            DisplayRelativePosOnCanvas();

    }

    #region Relative Position Calculation
    private void DisplayRelativePosOnCanvas()
    {
        vectorDisplayText.text =
            "X: " + relativePos.x.ToString("#.00") +
            ", Y: " + transform.position.y.ToString("#.00") + ", " +
            "Z: " + relativePos.z.ToString("#.00");
    }

    public void GetStartPos()
    {
        startPos = transform.position;
        updatePosition = true;
    }

    private void CaculateRelativePos()
    {
        relativePos.x = transform.position.x - startPos.x;
        relativePos.y = transform.position.y - startPos.y;
        relativePos.z = transform.position.z - startPos.z;
    }

    public void StopUpdatingRelativePos()
    {
        updatePosition = false;
    }
    #endregion

    #region Csound Communication
    private void SetCsoundChannelBasedOnPosition(CsoundChannelValuesBasedOnPosition[] csoundChannels, float minVectorRange, float maxVectorRange, float transformAxis)
    {
        foreach (CsoundChannelValuesBasedOnPosition data in csoundChannels)
        {
            float value =
                Mathf.Clamp(ScaleFloat.Scale(minVectorRange, maxVectorRange, data.minValue, data.maxValue, transformAxis), data.minValue, data.maxValue);

            if (!data.returnAbsoluteValue)
            {
                csound.SetChannel(data.channelName, value);
            }
            else
            {
                csound.SetChannel(data.channelName, Mathf.Abs(value));
            }

            //if (debug)
            //    Debug.Log(data.channelName + ": " + value);
        }
    }

    private void SetCsoundValuesX()
    {
        if (setXPositionTo == PositionReference.Absolute)
            SetCsoundChannelBasedOnPosition(csoundChannelsX, -vectorRanges.x, vectorRanges.y, transform.position.x);
        else
            SetCsoundChannelBasedOnPosition(csoundChannelsX, -vectorRanges.x, vectorRanges.x, relativePos.x);
    }

    private void SetCsoundValuesY()
    {
        if(setYPositionTo == PositionReference.Absolute)
            SetCsoundChannelBasedOnPosition(csoundChannelsY, 0, vectorRanges.y, transform.position.y);
        else
            SetCsoundChannelBasedOnPosition(csoundChannelsY, -vectorRanges.y, vectorRanges.y, relativePos.y);
    }

    private void SetCsoundValuesZ()
    {
        if (setZPositionTo == PositionReference.Absolute)
            SetCsoundChannelBasedOnPosition(csoundChannelsZ, -vectorRanges.z, vectorRanges.z, transform.position.z);
        else
            SetCsoundChannelBasedOnPosition(csoundChannelsZ, -vectorRanges.z, vectorRanges.z, relativePos.z);
    }
    #endregion
}

[System.Serializable]
public class CsoundChannelValuesBasedOnPosition
{
    public string channelName;
    public float minValue;
    public float maxValue;
    public bool returnAbsoluteValue = false;
}

