using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public enum SelectedColor { SoftBlue, Blue, Red, Yellow, White, Purple };
    private SelectedColor colorSelect;
    public GranuleraTemplates template;

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
        SwitchSoundBasedOnColor();
    }

    void SwitchSoundBasedOnColor()
    {
        switch (colorSelect)
        {
            case SelectedColor.SoftBlue:
                template.Template1();
                break;
            case SelectedColor.Blue:
                template.DigitalRain();
                break;
            case SelectedColor.Purple:
                template.FlutterCrystals();
                break;
            case SelectedColor.Red:
                template.NeonAbyss();
                break;
            case SelectedColor.White:
                template.Organ();
                break;
            case SelectedColor.Yellow:
                template.StereoCanonGenerator();
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SoftBlue"))
        {
            colorSelect = SelectedColor.SoftBlue;

            //SoftBlue = true;

            //Purple = Blue = Yellow = Red = White = false;
        }
        else if (other.gameObject.CompareTag("Purple"))
        {
            colorSelect = SelectedColor.Purple;

            //Purple = true;

            //SoftBlue = Blue = Yellow = Red = White = false;
        }
        else if (other.gameObject.CompareTag("Blue"))
        {
            colorSelect = SelectedColor.Blue;

            //Blue = true;

            //Purple = SoftBlue = Yellow = Red = White = false;
        }
        else if (other.gameObject.CompareTag("Yellow"))
        {
            colorSelect = SelectedColor.Yellow;

            //Yellow = true;

            //Purple = Blue = SoftBlue = Red = White = false;
        }
        else if (other.gameObject.CompareTag("Red"))
        {
            colorSelect = SelectedColor.Red;

            //Red = true;

            //Purple = Blue = Yellow = SoftBlue = White = false;
        }
        else if (other.gameObject.CompareTag("White"))
        {
            colorSelect = SelectedColor.White;

            //White = true;

            //Purple = Blue = Yellow = Red = SoftBlue = false;
        }
    }
}
