using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int nbrcubes = 0;
    public GameObject cube;  //prefab à faire spawn
    public GameObject plane;
    private int maxCube = 3; //nbr max de cubes en meme temps
    public float timer = 0f;
    private bool aSpawn = false;
    private bool canSpawn = true;
    public List<GameObject> cubesSpawned = new List<GameObject>();

    void Update()
    {
        //Lance la fonction
        SpawnTimer();
    }

    private void SpawnTimer()
    {
        foreach (GameObject cube in cubesSpawned)
        {
            nbrcubes = cubesSpawned.Count;
        }

        //Lance un timer de 3.5 secondes et ce reinitialise une fois celui ci atteint
        if (timer < 3.5f)
        {
            timer += Time.deltaTime;
        }

        if (timer > 3.5f)
        {
            print("time > 3.5");
            timer = 0f;
            if (nbrcubes < maxCube) //Si le nbr de cubes actuel est plus petit ou egale au nbr max de cube autorisé
            {
                canSpawn = true;
                if (canSpawn)
                {
                    //fais spawn un cube
                    aSpawn = false;
                    objectSpawn();
                }
            }
            else
            {
                print("Bool close");
                canSpawn = false;
            }
        }
    }

    void objectSpawn()
    {
        //Génère une position aléatoire et créer un nouvelle objet
        Vector3 randomPosition = GetRandomposition(plane);
        if (aSpawn == false)
        {
            GameObject newCube;
            newCube = Instantiate<GameObject>(cube, randomPosition, Quaternion.identity);
            cubesSpawned.Add(newCube);
            aSpawn = true;
        }
        else
        {
            aSpawn = false;
        }
    }
    
    public  Vector3 GetRandomposition(GameObject plane)
    {
        //Recupere la surface de la plane
        Mesh planeMesh = plane.GetComponent<MeshFilter>().mesh;
        Bounds bounds = planeMesh.bounds;
        //Stock le max et min de la surface 
        float minX = plane.transform.position.x - plane.transform.localScale.x * bounds.size.x * 0.40f;
        float minZ = plane.transform.position.z - plane.transform.localScale.z * bounds.size.z * 0.40f;
        
        //Retourne une valeur à utilisé pour généré l'objet
        Vector3 newVec = new Vector3(UnityEngine.Random.Range (minX, -minX), plane.transform.position.y,UnityEngine.Random.Range (minZ, -minZ));
        
        return newVec;
    }
}
