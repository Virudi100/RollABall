using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class player : MonoBehaviour
{
    private Rigidbody Player;
    public GameObject CanvasRestart;
    public GameObject Camera;
    public int score = 0;
    private int multiplateMove = 500;

    void Start()
    {
        //Recupere le rigidbody du player
        Player = gameObject.GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        //Input du joueur
        
        if (Input.GetKey(KeyCode.Z))
        {
            Player.AddForce(Vector3.forward * multiplateMove * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Player.AddForce(Vector3.left * multiplateMove * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Player.AddForce(Vector3.back * multiplateMove * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Player.AddForce(Vector3.right * multiplateMove * Time.fixedDeltaTime);
        }
    }

    private void Update()
    {
        //A 8 de score fais apparaitre le canvas de victoire
        if (score == 8)
        {
            CanvasRestart.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Detecte quand l'objet est un collectible et ajoute du score
        if (other.gameObject.CompareTag("collectible"))
        {
            score++;
            Camera.GetComponent<Generator>().cubesSpawned.Remove(other.gameObject);
            Camera.GetComponent<Generator>().nbrcubes -= 1;
            print("Score +1");
            Destroy(other.gameObject);
        }
    }
}
