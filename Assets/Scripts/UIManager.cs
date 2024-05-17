using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text scoreText;
    public GameObject gameOverPanel;
    public GameObject panelPause;
    public GameObject buttonPause;

    public void SetScoreText(string txt)
    {
        if(scoreText != null)
        {
            scoreText.text = txt;
        }

        
    }

    public void ShowGameOverPanel(bool show)
    {
        if(gameOverPanel)
        {
            gameOverPanel.SetActive(show);
        }
    }
    public void ShowPanelPause(bool show)
    {
        if (panelPause)
        {
            panelPause.SetActive(show);
        }
    }

    public void ShowButtonPause(bool show)
    {
        if (buttonPause)
        {
            buttonPause.SetActive(show);
        }
    }
}
