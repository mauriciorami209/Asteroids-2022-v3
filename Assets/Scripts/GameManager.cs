using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int s_Lives = 3;
    private static int s_MaxLives = 5;
    private static int m_score = 0;
    private static int s_GainLifeScore = 1000;

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
        }


    }
}
