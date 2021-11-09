using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpSkyColor : MonoBehaviour
{
    [SerializeField] private Material skyboxMaterial;
    public float duration = 3f;
    private Material skybox;

    private void Awake()
    {
        skybox = RenderSettings.skybox;
    }

    public void ChangeColor()
    {
        //StartCoroutine(LerpColors(1, duration));
        skybox.SetFloat("SkyColorLerp", 1);
        Debug.Log("CHANGE SKY COLOR");
    }

    public void ResetColor()
    {
        StartCoroutine(LerpColors(0, duration));
        Debug.Log("RESET SKY COLOR");
    }

    private IEnumerator LerpColors(float targetValue, float duration)
    {
        float currentTime = 0;
        float currentValue = skyboxMaterial.GetFloat("SkyColorLerp");
        float lerp = currentValue;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            lerp = Mathf.Lerp(currentValue, targetValue, currentTime / duration);
            skybox.SetFloat("SkyColorLerp", lerp);

            yield return null;
        }
        yield break;
    }
}
