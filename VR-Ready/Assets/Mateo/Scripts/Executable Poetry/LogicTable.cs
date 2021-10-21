using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicTable : MonoBehaviour
{
    [SerializeField] GameObject[] _words;
    [SerializeField] bool _word1, _word2, _word3, _word4, _word5;

    // Start is called before the first frame update
    void Start()
    {
        _word1 = _word2 = _word3 = _word4 = _word5 = false;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("1"))
        {
            _word1 = true;
        }
        else if (other.gameObject.CompareTag("2"))
        {
            _word2 = true;
        }
        else if (other.gameObject.CompareTag("3"))
        {
            _word3 = true;
        }
        else if (other.gameObject.CompareTag("4"))
        {
            _word4 = true;
        }
        else if (other.gameObject.CompareTag("5"))
        {
            _word5 = true;
        }
    }

}
