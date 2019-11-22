using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : MainSessionPanel
{
    [SerializeField]
    private Text EndScoreText = null;


    void Awake()
    {
        EndScoreText.text = "Score: " + ScoreManager.Score;
    }


    public void RetryButtonClick()
    {
        MainSession.RetryButtonClick();
    }
}
