using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime;
    private float m_spawnTime;
    private int m_Score;
    private bool m_GameOver;
    private bool m_isPaused;
    private int m_HighScore = 0; // Thêm biến lưu điểm cao nhất
    UIManager uI;

    void Start()
    {
        m_spawnTime = 0;    
        uI = FindObjectOfType<UIManager>();
        // Khởi tạo điểm cao nhất từ PlayerPrefs
        m_HighScore = PlayerPrefs.GetInt("HighScore", 0);
    }

  
    void Update()
    {
        if (m_GameOver)
        {
            m_spawnTime = 0;
            uI.ShowGameOverPanel(true);
            uI.ShowButtonPause(false);

          
            return;
        }
        if (!m_isPaused) 
        {
            m_spawnTime -= Time.deltaTime;
            if (m_spawnTime <= 0)
            {
                SpawnEnemy();
                m_spawnTime = spawnTime;
                uI.ShowButtonPause(true);
            }
            
        }
                              
    }
    public int GetHighScore()
    {
        return m_HighScore;
    }

    public void SpawnEnemy()
    {
        float randXpos = Random.Range(-8f, 8f);
        Vector2 spawnPos = new Vector2(randXpos, 7);
        if(enemy != null)
        {
            Instantiate(enemy,spawnPos, Quaternion.identity);
        }
    }

    public void SetCore(int value)
    {
        m_Score = value;
    }

    public int GetCore()
    {
        return m_Score;
    }

    public void ScoreInCrement()
    {
        if (m_GameOver)
        {
            return;
        }
        m_Score++;
        uI.SetScoreText("Score: " + m_Score);
    }

    public void SetGameOverState(bool state)
    {
        m_GameOver = state;

        if (m_GameOver)
        {
            // Lưu điểm số cao nhất nếu điểm số hiện tại cao hơn
            if (m_Score > m_HighScore)
            {
                m_HighScore = m_Score;
                PlayerPrefs.SetInt("HighScore", m_HighScore);
                PlayerPrefs.Save();
            }

        }

    }
    public bool GameOver()
    {
        return m_GameOver;
    }

    public void Replay()
    {
        SceneManager.LoadScene("GamePlay");

    }

    public void Exit()
    {
        SceneManager.LoadScene("MainScreen");
    }

    public void PauseGame() // Hàm tạm dừng chơi
    {
        m_isPaused = true;
        Time.timeScale = 0f;
        uI.ShowPanelPause(true);
    }

    public void ResumeGame() // Hàm tiếp tục chơi
    {
        m_isPaused = false;
        Time.timeScale = 1f; // Tiếp tục thời gian
        uI.ShowPanelPause(false);
    }


    public void ResetPlayerState()
    {
        // Đặt lại trạng thái của player
        m_Score = 0;
        m_GameOver = false;
        // Thực hiện các đặt lại khác nếu cần thiết, chẳng hạn như vị trí, v.v.
    }

}
