using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerlvl3 : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject Camera;
    private float speedy = 8f;
    private int score = 0;
    public GameObject CanvasRestart;
    
    void Start()
    {
        //Recupere le rigidbody du player
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    { //Input du joueur par rapport à l'orientation de la caméra
        if (Input.GetKey(KeyCode.Z))
        {
            rb.AddForce(Camera.transform.forward * speedy);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Camera.transform.right * speedy);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddForce(Camera.transform.right * -1 * speedy);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Camera.transform.forward * -1 * speedy);
        }
        
        //Fais apparaitre le canvas de victoire une fois a l'arriver
        if (score == 1)
        {
            CanvasRestart.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    { // permet de "recuperer" l'objet nécéssaire
        if (other.gameObject.CompareTag("collectible"))
        {
            score = 1;
        }
    }
}
