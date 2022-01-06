using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayer : MonoBehaviour
{
    public GameObject player;
    
    //block la rotation et donne la position du player a l'empty GameObject qui vas servir de parent a la caméra 
    void Update()
    {
        this.gameObject.GetComponent<Transform>().eulerAngles = new Vector3(0,0,0);
        this.gameObject.GetComponent<Transform>().position = player.GetComponent<Transform>().position;
    }
}
