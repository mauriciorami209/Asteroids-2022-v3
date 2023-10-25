using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    
    [SerializeField]
    private Image[] LivesIcons;
    [SerializeField]
    private TextMeshProUGUI m_textScore;

   

    private void Start()
    {

        GameManager.OnUpdateLives += UpdateLives;
        GameManager.OnUpdateScore += UpdateScore;
        UpdateLives(GameManager.Lives);
        UpdateScore(GameManager.Score);
    }

    private void UpdateLives(int lives)
    {
        for (int i = 0; i < LivesIcons.Length; i++)
        {
            LivesIcons[i].enabled = i < lives;
        }
    }


    void Update()
    {
      

    }
    public void HideLive (int index)
    {
        Debug.Log(index);
        LivesIcons[index].enabled = false;
    }

    public void UpdateScore(float score)
    {
        m_textScore.text = "" + score;
       // m_textScore.text = score.ToString();

    }
}
