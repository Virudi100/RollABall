using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    private float _rotationSpeed = 0.2f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up*_rotationSpeed,Space.World);
    }
}
