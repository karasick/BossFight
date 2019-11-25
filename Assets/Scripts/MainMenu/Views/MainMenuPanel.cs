using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : MonoBehaviour
{
    [SerializeField]
    protected MainMenu MainMenu;


    public void BackButtonClick()
    {
        MainMenu.BackButtonClick();
    }
}
