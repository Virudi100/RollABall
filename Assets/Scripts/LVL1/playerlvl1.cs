using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerlvl1 : MonoBehaviour
{
    private Rigidbody Player;
    public GameObject CanvasRestart;

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
            print("Score +1");
        }
    }
}
