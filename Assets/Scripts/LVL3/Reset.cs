using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    //Relance le niveau quand le joueur tombe dans le vide
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level 3");
        }
        
    }
    
    //relance le niveau
    public void Restart()
    {
        SceneManager.LoadScene("Level 3");
    }

    //lance le prochaine niveau
    public void NextLevel()
    {
        SceneManager.LoadScene("Main");
    }
}
