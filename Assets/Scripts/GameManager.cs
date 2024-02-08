using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    private static Pool<BulletController> m_BulletPool;
    private static Pool<AsteroidController> m_AsteroidPool;

    public static Pool<BulletController> BulletPool => m_BulletPool;


    private static int s_Lives = 3;
    private static int s_MaxLives = 5;
    private static int m_score = 0;
    private static int s_GainLifeScore = 1000;

    public static OnUpdateLives OnUpdateLives;
    public static OnUpdateScore OnUpdateScore;
    public GameObject m_BulletPrefab;
    public void Start()
    {
        m_BulletPool = new Pool<BulletController>(5, m_BulletPrefab);
    }

    public static int Lives
    {
        get { return s_Lives; }
        set
        {
            s_Lives = value;
            if (s_Lives > s_MaxLives)
            {
                s_Lives = s_MaxLives;
            }

            if (OnUpdateLives != null)
                OnUpdateLives(s_Lives);
        }
    }
    public static int Score
    {
        get { return m_score; }
        set
        {
            m_score = value;
            if (m_score > s_GainLifeScore)
            {
                Lives += 1;
                s_GainLifeScore *= 2;
            }

            if (OnUpdateScore != null)
                OnUpdateScore(m_score);
        }

    }
    public static void LoadScene(string sceneName)
    {
        OnUpdateLives = null;
        OnUpdateScore = null;

        if (sceneName == "Game Over")

            WriteScore();

        SceneManager.LoadScene(sceneName);
    }

    private static void WriteScore()
    {
        // donde quiero escribir la informacion
        string filePath = Path.Combine(Application.dataPath, "scores.txt");

        //creo un stream de escritura para serializar el score
        StreamWriter fileWriter = File.AppendText(filePath);

        //escribo una linea de texto en el archivo de score
        fileWriter.Write(m_score);

        // cierro el stream de escritura
        fileWriter.Close();

    }

}


public delegate void OnUpdateLives(int lives);

public delegate void OnUpdateScore(float score);