using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBox : MonoBehaviour
{
    [SerializeField] AudioClip[] possibleClips;
    AudioSource _source;
    [SerializeField] bool[] tableLevel;

    [SerializeField] Transform _port; //port a and b
    public float _distance; //store distances of cube and ports (y and z)

    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("manija"))
        {
            _source.clip = possibleClips[Random.Range(0, possibleClips.Length)];
            _distance = Vector3.Distance(_port.position, transform.position);
            _source.pitch = Map(_distance, 0.08f, 0.17f, 0.5f, 3f);
            _source.Play();

        }
        
    }

    // Map Function
    float Map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }


}
