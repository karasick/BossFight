using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MainMenuPanel
{
    [SerializeField]
    private Sprite[] MenuSprites = null;


    public Sprite[] GetMenuSprites()
    {
        return MenuSprites;
    }


    public void ChangeStyleButtonClick()
    {
        MainMenu.ChangeStyleButtonClick();
    }
}
