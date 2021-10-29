using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelOfTime : MonoBehaviour
{
    [SerializeField] bool isSpinning;
    [SerializeField] float rotationSpeed;

    [SerializeField] Transform _portSpeedOfRotation;
    public float _distance;

    // Start is called before the first frame update
    void Start()
    {
        isSpinning = false;  
    }


    // Update is called once per frame
    void Update()
    {
        _distance = Vector3.Distance(_portSpeedOfRotation.position, transform.position);

        

        if (isSpinning)
        {

            rotationSpeed = Map(_distance, 0.05f, 0.17f, 0.05f, 3f);
            transform.Rotate(new Vector3(0, 90, 0) * rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, 0) * 0 * rotationSpeed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("wheel")){
            if (!isSpinning)
            {
                isSpinning = true;
            }
            else
            {
                isSpinning = false;
            }

        }
    }

    // Map Function
    float Map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }

}
