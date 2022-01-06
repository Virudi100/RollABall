using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _rigidbody.AddForce(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ConstantRotation>() != null)
        {
            Destroy(other.gameObject);
        }
    }
}
