using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSessionPanel : MonoBehaviour
{
    [SerializeField]
    protected MainSession MainSession;

    public void ExitButtonClick()
    {
        MainSession.ExitButtonClick();
    }
}