using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSession : MonoBehaviour
{
    // Views binding
    [SerializeField]
    private GameObject[] Panels;

    // Active player
    [SerializeField]
    public MainPlayer MainPlayer;

    // Active panel
    public string ActivePanel { get; private set; }

    // Active menu sprite
    public string ActiveScreenOrientation { get; private set; }

    // Active Character level
    public int ActiveCharacterLevel { get; private set; }

    // Is player lose
    public bool IsLose = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        SetActivePanel("GamePanel");
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}


    /*
     * MainSession handlings
     * 
     */
    private void SetActivePanel(string panelNameNew)
    {
        foreach (GameObject Panel in Panels)
        {
            if (Panel.name == panelNameNew)
            {
                // Show Active panel
                Panel.SetActive(true);
                ActivePanel = panelNameNew;
            }
            else
            {
                // Hide another Panels
                Panel.SetActive(false);
            }
        }
    }

    private GameObject GetPanel(string panelName)
    {
        foreach (GameObject Panel in Panels)
        {
            if (Panel.name == panelName)
            {
                return Panel;
            }
        }
        return null;
    }

    private string CheckScreenOrientation()
    {
        if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            return "horizontal";
        }
        else if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            return "vertical";
        }
        else
        {
            return "square";
        }
    }

    public void CloseSession()
    {
        Time.timeScale = 0f;
        IsLose = true;
        SetActivePanel("EndGamePanel");
    }


    public float GetPlayerAttackDamage()
    {
        return MainPlayer.Profile.AttackDamage;
    }


    /*
     * Views handlings
     * 
     */
    public void ShootButtonClick()
    {
        MainPlayer.ShootButtonClick();
    }

    public void BlockButtonClick()
    {
        throw new NotImplementedException();
    }


    public void ScreenTap()
    {
        throw new NotImplementedException();
    }


    public void PauseButtonClick()
    {
        Time.timeScale = 0f;
        SetActivePanel("PausePanel");
    }


    public void BackButtonClick()
    {
        Time.timeScale = 1f;
        SetActivePanel("GamePanel");
    }


    public void RetryButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }


    public void ExitButtonClick()
    {
        Application.Quit();
    }
}
