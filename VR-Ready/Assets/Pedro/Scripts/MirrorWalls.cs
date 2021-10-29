using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorWalls : MonoBehaviour
{

    public GameObject otherWall;
    public float otherWallX;

    // Update is called once per frame
    void Update()
    {
        otherWallX = -transform.position.x;

        if (transform.position.x > 0)
            transform.position = new Vector3(Mathf.Clamp(Mathf.Abs(transform.position.x), 4, 7), transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(-Mathf.Clamp(Mathf.Abs(transform.position.x), 4, 7), transform.position.y, transform.position.z);

    }

    private void OnCollisionStay(Collision collision)
    {
        otherWall.transform.position = new Vector3(otherWallX, transform.position.y, transform.position.z);
    }
}
