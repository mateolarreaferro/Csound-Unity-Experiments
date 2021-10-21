using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody rb;
    [Range(0.1f, 5f)]
    [SerializeField] float _speed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMov = Input.GetAxis("Horizontal") * Time.deltaTime;
        float zMov = Input.GetAxis("Vertical") * Time.deltaTime;

        rb.AddForce(new Vector3(xMov, this.transform.position.y, zMov) * _speed);
        
    }
}
