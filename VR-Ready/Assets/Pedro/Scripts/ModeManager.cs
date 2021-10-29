using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public GameObject[] Objects;
    public GameObject[] UIObjects;

    public void turnAllOffBut(int whichOn)
    {
        foreach (var Object in Objects)
        {
            Object.SetActive(false);
        }
        foreach (var UIObject in UIObjects)
        {
            UIObject.SetActive(false);
        }

        switch (whichOn)
        {
            case 0:
                Objects[0].SetActive(true);
                UIObjects[0].SetActive(true);
                break;
            case 01:
                Objects[1].SetActive(true);
                UIObjects[1].SetActive(true);
                break;
            case 02:
                Objects[2].SetActive(true);
                UIObjects[2].SetActive(true);
                break;
            case 03:
                Objects[3].SetActive(true);
                UIObjects[3].SetActive(true);
                break;
            case 04:
                Objects[4].SetActive(true);
                UIObjects[4].SetActive(true);
                break;
            case 05:
                Objects[5].SetActive(true);
                UIObjects[5].SetActive(true);
                break;
        }
    }
}
