using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene()

    {
        GameManager.Lives = 3;
        GameManager.Score = 0;
        SceneManager.LoadScene("Asteroids 2022 v2 main");
        
    }
}
