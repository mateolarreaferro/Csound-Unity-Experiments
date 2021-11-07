using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    [SerializeField] bool SoftBlue = false;
    [SerializeField] bool Blue = false;
    [SerializeField] bool Red = false;
    [SerializeField] bool Yellow = false;
    [SerializeField] bool White = false;
    [SerializeField] bool Purple = false;




    // Update is called once per frame
    void Update()
    {
        //if (gameObject.GetComponent<Drawing>().isDrawing == true)
        //{

        //}
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SoftBlue"))
        {
            SoftBlue = true;

            Purple = Blue = Yellow = Red = White = false;
        }
        else if (other.gameObject.CompareTag("Purple"))
        {
            Purple = true;

            SoftBlue = Blue = Yellow = Red = White = false;
        }
        else if (other.gameObject.CompareTag("Blue"))
        {
            Blue = true;

            Purple = SoftBlue = Yellow = Red = White = false;
        }
        else if (other.gameObject.CompareTag("Yellow"))
        {
            Yellow = true;

            Purple = Blue = SoftBlue = Red = White = false;
        }
        else if (other.gameObject.CompareTag("Red"))
        {
            Red = true;

            Purple = Blue = Yellow = SoftBlue = White = false;
        }
        else if (other.gameObject.CompareTag("White"))
        {
            White = true;

            Purple = Blue = Yellow = Red = SoftBlue = false;
        }
    }
}
