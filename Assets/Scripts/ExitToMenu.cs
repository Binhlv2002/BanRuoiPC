using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMenu : MonoBehaviour
{
    GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>(); // Tìm đối tượng GameController
    }
    public void ExitToMainMenu()
    {
        if (gameController != null)
        {
            gameController.SetGameOverState(false); // Đặt lại trạng thái gameOver của GameController thành false
        }
        SceneManager.LoadScene("MainScreen");
    }
}
