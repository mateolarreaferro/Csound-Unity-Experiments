using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour
{

    [SerializeField] GameObject[] _objects;
    [Range(0, 1000)]
    [SerializeField] int _buildings;
    [SerializeField] float _offsetLimits;
    [SerializeField] float _range;



    // Start is called before the first frame update
    void Start()
    {
        MakeCity();
        
    }

    void MakeCity()
    {
        for (int i = 0; i < _buildings; i++)
        {

            Vector3 positionOfObject = new Vector3(Random.Range(-_range + _offsetLimits, _range - _offsetLimits),
                this.transform.position.y,
                Random.Range(-_range + _offsetLimits, _range - _offsetLimits));

            GameObject copy = Instantiate(_objects[Random.Range(0, _objects.Length)]);
            copy.transform.position = positionOfObject;
            

            copy.name = "Building #" + i;
        }
    }

}
