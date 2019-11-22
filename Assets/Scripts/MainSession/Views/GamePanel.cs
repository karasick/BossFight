using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MainSessionPanel
{
    [SerializeField]
    private Text CurrentLevelText = null;
    [SerializeField]
    private Text CurrentScoreText = null;
    [SerializeField]
    private Text CurrentExpText = null;
    [SerializeField]
    private Image CurrentHPBar = null;

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
        CurrentLevelText.text = "Lvl: " + MainSession.MainPlayer.Profile.Level;
        CurrentScoreText.text = "Score: " + ScoreManager.Score;
        CurrentExpText.text = "Exp: " + MainSession.MainPlayer.Profile.CurrentExp + "/" + MainSession.MainPlayer.Profile.ExpToLevelUp;
    }

    public void SetHPInformation()
    {
        CurrentHPBar.fillAmount = MainSession.MainPlayer.Profile.CurrentHealth / MainSession.MainPlayer.Profile.MaxHealth;
    }


    public void PauseButtonClick()
    {
        MainSession.PauseButtonClick();
    }

    public void ShootButtonClick()
    {
        MainSession.ShootButtonClick();
    }

    public void BlockButtonClick()
    {
        MainSession.BlockButtonClick();
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
                MainSession.ScreenTap();
            }
        }

    }
}
