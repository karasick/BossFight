using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLoader : SceneLoader<GameSession>
{
    void Start()
    {
        SceneToLoad = "MainMenu";
    }
}

