using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public bool IsRotating { get; set; }

    void Update()
    {
        if (IsRotating)
        {
            GetComponent<MeshRenderer>().enabled = true;
            transform.RotateAround(transform.position, Vector3.up, 1f);
        }
    }
}
