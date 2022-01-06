using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    
    private float X;
    private float Y;
    public float Sensitivity = 2;
    private bool isunlock = false;
    
    private void Awake()
    {
        Vector3 euler = transform.rotation.eulerAngles;
        X = euler.x;
        //bloque la souris a l'interieur de l'écran de jeu
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    private void Update()
    {
        //Gere le deplacement de la caméra avec la souris
        const float MIN_X = 0.0f;
        const float MAX_X = 360.0f;

        X += Input.GetAxis("Mouse X") * (Sensitivity * Time.deltaTime);
        if (X < MIN_X) X += MAX_X;
        else if (X > MAX_X) X -= MAX_X;

        transform.rotation = Quaternion.Euler(0.0f, X, 0.0f);
        
        //Press "SPACE" pour débloqué ou bloqué la souris dans l'écran de jeu

        if (Input.GetKey(KeyCode.Space))
        {
            if (isunlock == false)
            {
                Cursor.lockState = CursorLockMode.None;
                isunlock = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                isunlock = false;
            }
        }
            
    }
}
