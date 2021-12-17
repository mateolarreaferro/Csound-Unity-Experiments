using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRandomForce : MonoBehaviour
{
    [SerializeField] private float strength;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 randomVector = new Vector3(Random0to1(), Random0to1(), Random0to1());

        rb.AddForce(randomVector * strength, ForceMode.Impulse);
    }

    private float Random0to1()
    {
        float random = Random.Range(0, 1);
        float rounding = random > 0.5f ? 1 : 0.5f;
        print(rounding);
        return rounding;
    }
}
