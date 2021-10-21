using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtGeneration : MonoBehaviour
{

    [SerializeField] GameObject _original;

    [Range(0, 300)]
    [SerializeField] int _parts;
    [SerializeField] float _offsetLimits;
    [SerializeField] float _rangeZ;
    [SerializeField] float _rangeY;


    

    // Start is called before the first frame update
    void Start()
    {

        MakePiece();
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    void MakePiece()
    {
        for (int i = 0; i < _parts; i++)
        {

            Vector3 positionOfNewObject = new Vector3(_original.transform.position.x, _original.transform.position.y
                + Random.Range(-_rangeY + _offsetLimits, _rangeY - _offsetLimits), _original.transform.position.z
                + Random.Range(-_rangeZ + _offsetLimits, _rangeZ - _offsetLimits));

            GameObject copy = Instantiate(_original);
            copy.transform.position = positionOfNewObject;


            copy.name = "Object #" + i;
        }
    }
}





