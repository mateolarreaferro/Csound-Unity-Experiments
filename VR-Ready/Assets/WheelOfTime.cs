using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelOfTime : MonoBehaviour
{
    [SerializeField] bool isSpinning;
    [SerializeField] float rotationSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        isSpinning = true;  
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpinning)
        {
            transform.Rotate(new Vector3(0, 90, 0) * rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, 0) * 0 * Time.deltaTime);
        }
        
    }
    
}
