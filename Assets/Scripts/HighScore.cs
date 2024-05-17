using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScoreText;

    public void SetHighScoreText(string txt)
    {
        if (highScoreText != null)
        {
            highScoreText.text = txt;
        }


    }



}
