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

   

    void Start()
    {
       // m_textScore.text = "" + Score;

        


        //Slow motion
        
        /*  if (GameManager.Lives == 2)
          {
              LivesIcons[2].enabled = false;
          }
          else if (GameManager.Lives == 1)
          {
              LivesIcons[2].enabled = false;
              LivesIcons[1].enabled = false;
          }
          else if (GameManager.Lives == 0)
          {
              LivesIcons[2].enabled = false;
              LivesIcons[1].enabled = false;
              LivesIcons[0].enabled = false;
          } */

    }

    public void HideLive ( int index)
    {
        Debug.Log(index);
        LivesIcons[index].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        int numLives = GameManager.Lives;
        for (int i = 0; i < LivesIcons.Length; i++)
        {
            LivesIcons[i].enabled = i < numLives;
        }

        UpdateScore();

    }

    public void UpdateScore()
    {
        m_textScore.text = "" + GameManager.Score;

    }
}
