using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionLoader : SceneLoader<MainMenu>
{
    void Start()
    {
        SceneToLoad = "GameSession";
    }
}
