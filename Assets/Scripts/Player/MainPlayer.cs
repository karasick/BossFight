using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    [SerializeField]
    protected MainSession MainSession;

    public PlayerProfile Profile;

    private float TimeBeforeRegeneration = 0;

    // Start is called before the first frame update
    void Start()
    {
        CheckHealth();
    }

    // Update is called once per frame
    void Update()
    {
        RegenerateHealth();
    }

    private void CheckHealth()
    {
        if(Profile.CurrentHealth <= 0)
        {
            Profile.ActivePlayerState = PlayerState.Dead;
            MainSession.CloseSession();
        }
        //else
        //{
        //    Profile.ActivePlayerState = PlayerState.Alive;
        //}
    }

    private void RegenerateHealth()
    {
        CheckHealth();

        //Debug.Log(Profile.CurrentHealth);

        if(TimeBeforeRegeneration < Profile.RegenerationHealthSpeed)
        {
            TimeBeforeRegeneration += Time.deltaTime;
        }
        else
        {
            if (Profile.CurrentHealth < Profile.MaxHealth)
            {
                Profile.CurrentHealth += Profile.RegenerationHealthPoints;
            }
            else
            {
                Profile.CurrentHealth = Profile.MaxHealth;
            }

            TimeBeforeRegeneration = 0;
        }
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Profile.CurrentHealth = 0;
        }
    }
}
