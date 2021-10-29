using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMover : MonoBehaviour
{
    public float timer;
    public float offSet;
    public float amplitude;
    public float newX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        newX = Mathf.Sin(timer)* amplitude + offSet;
        transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
    }
}
