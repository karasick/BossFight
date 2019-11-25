using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    [SerializeField]
    protected MainSession MainSession;

    [SerializeField]
    public PlayerProfile Profile;

    [SerializeField]
    protected GameObject Aim;

    [SerializeField]
    protected GameObject Fireball;

    private float FireballSpeed = 10;
    private float FireballTime = 5;

    private float TimeBeforeRegeneration = 0;

    // Start is called before the first frame update
    void Start()
    {
        CheckHealth();
        SetUpPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        RegenerateHealth();
    }

    private void SetUpPlayer()
    {
        Profile.ActivePlayerState = PlayerState.Alive;
        Profile.CurrentHealth = Profile.MaxHealth;
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

    public void ShootButtonClick()
    {
        GameObject fireball = Instantiate(Fireball, Aim.transform) as GameObject;
        //fireball.transform.localScale = new Vector3(100, 100, 100);
        Rigidbody fireballRigidbody = fireball.GetComponent<Rigidbody>();
        fireballRigidbody.velocity = transform.forward * FireballSpeed;
        Destroy(fireball, FireballTime);
    }
}
