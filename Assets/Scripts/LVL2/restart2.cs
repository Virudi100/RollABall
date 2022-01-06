using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart2 : MonoBehaviour
{
    //Redemarre le niveau
    public void Restart()
    {
        SceneManager.LoadScene("Level 2");
    }
    //lance le prochain niveau
    public void NextLevel()
    {
        SceneManager.LoadScene("Level 3");
    }
}
