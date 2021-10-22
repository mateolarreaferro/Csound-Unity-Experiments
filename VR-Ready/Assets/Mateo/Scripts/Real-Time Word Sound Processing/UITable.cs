using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITable : MonoBehaviour
{
    public GameObject _table;

    public void AdjustHeight(float height)
    {
        _table.transform.position = new Vector3(_table.transform.position.x, height, _table.transform.position.z);
    }
}
