using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    private Vector3 rotation;
    
    void FixedUpdate()
    {
        //fais tourner le cube en continue
        rotation.y = 50f * Time.deltaTime;
        this.gameObject.transform.Rotate(rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //detruit l'objet lors de la collision
            Destroy(this.gameObject);
        }
    }
}
