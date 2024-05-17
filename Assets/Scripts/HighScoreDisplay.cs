using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplay : MonoBehaviour
{
    GameController gameController;
    public Text highScoreText;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        UpdateHighScoreText();
    }

    // Hàm cập nhật điểm cao nhất trên giao diện
    void UpdateHighScoreText()
    {
        if (highScoreText != null && gameController != null)
        {
            int highScore = PlayerPrefs.GetInt("HighScore", 0);
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }
}
