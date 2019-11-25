using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionPanel : MonoBehaviour
{
    [SerializeField]
    protected GameSession GameSession;

    public void ToMenuButtonClick()
    {
        GameSession.ToMenuButtonClick();
    }
}