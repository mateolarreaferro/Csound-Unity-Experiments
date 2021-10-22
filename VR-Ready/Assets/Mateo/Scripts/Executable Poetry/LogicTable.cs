using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicTable : MonoBehaviour
{
    
    //Which word should be playing
    public bool[] Dominant = new bool[6];

    //Quality (for FFT)
    public bool _negative, _neutral, _positive;
    [SerializeField] Material LEDMaterial = null;


    // Start is called before the first frame update
    void Start()
    {
        
        //Init Dominants
        for (int i = 0; i < Dominant.Length; i++)
        {
            Dominant[i] = false;
        }

        //Default Material for LED system
        LEDMaterial.SetColor("_ColorLED", Color.grey);


    }



    private void Update()
    {
        if (_negative)
        {
            LEDMaterial.SetColor("_ColorLED", Color.blue);
        }
        else if (_neutral)
        {
            LEDMaterial.SetColor("_ColorLED", Color.gray);
        }
        else if (_positive)
        {
            LEDMaterial.SetColor("_ColorLED", Color.green);
        }
        else
        {
            LEDMaterial.SetColor("_ColorLED", Color.grey);
        }
    }





    // ENTER THE TABLE

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("amnesia"))
        {
           for (int i = 0; i < Dominant.Length; i++)
            {
                Dominant[i] = false;
            }

            Dominant[0] = true;
            _negative = true;

            _neutral = _positive = false;

        }
        else if (other.gameObject.CompareTag("immortal"))
        {
            for (int i = 0; i < Dominant.Length; i++)
            {
                Dominant[i] = false;
            }

            Dominant[1] = true;
            _positive = true;

            _neutral = _negative = false;
        }
        else if (other.gameObject.CompareTag("trapped"))
        {
            for (int i = 0; i < Dominant.Length; i++)
            {
                Dominant[i] = false;
            }

            Dominant[2] = true;
            _negative = true;

            _neutral = _positive = false;
        }
        else if (other.gameObject.CompareTag("orthogonal"))
        {
            for (int i = 0; i < Dominant.Length; i++)
            {
                Dominant[i] = false;
            }

            Dominant[3] = true;
            _neutral = true;

            _negative = _positive = false;
        }
        else if (other.gameObject.CompareTag("enlightened"))
        {
            for (int i = 0; i < Dominant.Length; i++)
            {
                Dominant[i] = false;
            }

            Dominant[4] = true;
            _positive = true;

            _neutral = _negative = false;
        }
        else if (other.gameObject.CompareTag("paradox"))
        {
            for (int i = 0; i < Dominant.Length; i++)
            {
                Dominant[i] = false;
            }

            Dominant[5] = true;
            _neutral = true;

            _negative = _positive = false;
        }
    }

    // EXIT THE TABLE

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("amnesia"))
        {

            Dominant[0] = false;
            _negative = false;

        }
        else if (other.gameObject.CompareTag("immortal"))
        {
            Dominant[1] = false;
            _positive = false;
        }
        else if (other.gameObject.CompareTag("trapped"))
        {
            Dominant[2] = false;
            _negative = false;
        }
        else if (other.gameObject.CompareTag("orthogonal"))
        {
            Dominant[3] = false;
            _neutral = false;
        }
        else if (other.gameObject.CompareTag("enlightened"))
        {
            Dominant[4] = false;
            _positive = false;
        }
        else if (other.gameObject.CompareTag("paradox"))
        {
            Dominant[5] = false;
            _neutral = false;


        }

    }

}
