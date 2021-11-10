using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//TODO
//Make X and Z axis relative to rotation
//Fix the FMAMp 0-1 range thing

public class CsoundSendValuesBasedOnHandPosition : MonoBehaviour
{
    [SerializeField] private Vector3 vectorRanges;

    //Csound
    [SerializeField] private CsoundUnity csound;
    [SerializeField] private CsoundChannelValuesBasedOnPosition[] csoundChannelsX;
    [SerializeField] private CsoundChannelValuesBasedOnPosition[] csoundChannelsY;
    [SerializeField] private CsoundChannelValuesBasedOnPosition[] csoundChannelsZ;

    private Vector3 startPos;
    private Vector3 relativePos;
    private bool updateRelativePos = false;

    //UI TEST
    public TextMeshProUGUI vectorDisplayText;

    // Update is called once per frame
    void Update()
    {
        if (updateRelativePos)
        {
            CaculateRelativePos();
            SetCsoundChannelX();
            SetCsoundChannelY();
            SetCsoundChannelZ();

            DisplayRelativePosOnCanvas();
        }
    }

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
        updateRelativePos = true;
    }

    private void CaculateRelativePos()
    {
        relativePos.x = transform.position.x - startPos.x;
        relativePos.y = transform.position.y - startPos.y;
        relativePos.z = transform.position.z - startPos.z;
    }

    public void StopUpdatingRelativePos()
    {
        updateRelativePos = false;
    }

    private void SetCsoundChannelY()
    {
        foreach(CsoundChannelValuesBasedOnPosition data in csoundChannelsY)
        {
            if(!data.mirror)
                csound.SetChannel(data.channelName, ScaleFloat.Scale(0, vectorRanges.y, data.minValue, data.maxValue, transform.position.y));
            else
                csound.SetChannel(data.channelName, ScaleFloat.Scale(0, vectorRanges.y, data.minValue, data.maxValue, Mathf.Abs(transform.position.y)));
        }
    }

    private void SetCsoundChannelX()
    {
        foreach (CsoundChannelValuesBasedOnPosition data in csoundChannelsX)
        {
            if(!data.mirror)
                csound.SetChannel(data.channelName, ScaleFloat.Scale(-vectorRanges.x, vectorRanges.x, data.minValue, data.maxValue, relativePos.x));
            else
                csound.SetChannel(data.channelName, ScaleFloat.Scale(-vectorRanges.x, vectorRanges.x, data.minValue, data.maxValue, Mathf.Abs(relativePos.x)));

        }
    }

    private void SetCsoundChannelZ()
    {
        foreach (CsoundChannelValuesBasedOnPosition data in csoundChannelsZ)
        {
            if(!data.mirror)
                csound.SetChannel(data.channelName, ScaleFloat.Scale(-vectorRanges.z, vectorRanges.z, data.minValue, data.maxValue, relativePos.z));
            else
                csound.SetChannel(data.channelName, ScaleFloat.Scale(-vectorRanges.z, vectorRanges.z, data.minValue, data.maxValue, Mathf.Abs(relativePos.z)));
        }
    }
}

[System.Serializable]
public class CsoundChannelValuesBasedOnPosition
{
    public string channelName;
    public float minValue;
    public float maxValue;
    public bool mirror;
}

