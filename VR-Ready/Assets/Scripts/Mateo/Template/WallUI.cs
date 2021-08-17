using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallUI : MonoBehaviour
{
    [SerializeField] GameObject[] _objects;
    [SerializeField] GameObject referencePoint;
    Vector3 _offset;


    [SerializeField] GameObject _sun;

    [SerializeField] CanvasGroup canvasGroup;
    bool canvasDisplay = false;

    public void NewObject() //Instantiate new Object in the scene
    {
        _offset = new Vector3(referencePoint.transform.position.x + Random.Range(0, 5f), referencePoint.transform.position.y + Random.Range(0, 5f),
            referencePoint.transform.position.z + Random.Range(0, 5f));
        GameObject copiedObject = Instantiate(_objects[Random.Range(0, _objects.Length)], referencePoint.transform.position + _offset , referencePoint.transform.rotation);
        

    }

    public void SunRotation() //Moves the sun
    {
        _sun.transform.Rotate(new Vector3(90, 90, 90) * Time.deltaTime * 10f);
    }

    public void Instructions() //Turns ON/OFF the words from 'Instruction'
    {
        if (!canvasDisplay)
        {
            canvasGroup.alpha = 1;
            canvasDisplay = true;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasDisplay = false;
        }
    }
}

