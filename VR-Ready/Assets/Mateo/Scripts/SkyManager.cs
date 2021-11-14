using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyManager : MonoBehaviour
{

    [SerializeField] GameObject[] _lights;
    [SerializeField] float _speed;
    [SerializeField] float _angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _lights.Length; i++)
        {
            _lights[i].transform.Rotate(new Vector3(_angle, _angle, _angle) * Time.deltaTime * _speed);
        }
        
    }
}
