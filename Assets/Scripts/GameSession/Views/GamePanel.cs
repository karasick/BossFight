using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : GameSessionPanel
{
    [SerializeField]
    private Text CurrentLevelText = null;
    [SerializeField]
    private Text CurrentScoreText = null;
    [SerializeField]
    private Text CurrentExpText = null;
    [SerializeField]
    private Image CurrentHPBar = null;
    [SerializeField]
    private Text CurrentHPText = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetTextInformation();
        SetHPInformation();
    }


    private void SetTextInformation()
    {
        CurrentLevelText.text = "Lvl: " + GameSession.MainPlayer.Profile.Level;
        CurrentScoreText.text = "Score: " + ScoreManager.Score;
        CurrentExpText.text = "Exp: " + GameSession.MainPlayer.Profile.CurrentExp + "/" + GameSession.MainPlayer.Profile.ExpToLevelUp;
    }

    public void SetHPInformation()
    {
        CurrentHPBar.fillAmount = GameSession.MainPlayer.Profile.CurrentHealth / GameSession.MainPlayer.Profile.MaxHealth;
        CurrentHPText.text = System.Math.Floor(GameSession.MainPlayer.Profile.CurrentHealth).ToString();
    }


    public void PauseButtonClick()
    {
        GameSession.PauseButtonClick();
    }

    public void ShootButtonClick()
    {
        GameSession.ShootButtonClick();
    }

    public void BlockButtonClick()
    {
        GameSession.BlockButtonClick();
    }

    private void CheckTouchInput()
    {
        if(Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log("touch");
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                GameSession.ScreenTap();
            }
        }

    }
}
