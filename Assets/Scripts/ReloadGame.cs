using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Scores:");

        string path = Path.Combine(Application.dataPath, "scores.txt");

        StreamReader streamReader = new StreamReader(path);

        string line = streamReader.ReadLine();
        while (!string.IsNullOrEmpty(line))
        {
            Debug.Log(line);
            line = streamReader.ReadLine();
        }

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
