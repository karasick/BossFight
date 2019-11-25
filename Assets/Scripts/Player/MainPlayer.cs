using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    [SerializeField]
    protected Camera Camera;

    [SerializeField]
    protected GameSession GameSession;

    [SerializeField]
    public PlayerProfile Profile;

    [SerializeField]
    protected GameObject Aim;

    [SerializeField]
    protected GameObject Fireball;

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
            GameSession.CloseSession();
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


    public void GetExp(int exp = 0)
    {
        Profile.CurrentExp += exp;

        CheckLevelUp();
    }


    private void CheckLevelUp()
    {
        if(Profile.CurrentExp >= Profile.ExpToLevelUp)
        {
            Profile.CurrentExp -= Profile.ExpToLevelUp;
            Profile.ExpToLevelUp *= 2;
            Profile.Level++;

            CheckLevelUp();
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
        RaycastHit hit;

        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit))
        {
            if(hit.transform.GetComponent<BoxCollider>())
            {
                //Debug.Log("hit object");
                //Debug.Log(hit.transform.position);
            }
            else
            {
                //Debug.Log("hit none");
                //Debug.Log(hit.transform.position);
            }
        }

        GameObject fireball = Instantiate(Fireball, Aim.transform.position, Camera.transform.rotation);


        //fireball.transform.Rotate(Quaternion.LookRotation());
        //fireball.transform.localScale = new Vector3(100, 100, 100);
        //Rigidbody fireballRigidbody = fireball.GetComponent<Rigidbody>();
        //fireballRigidbody.velocity = transform.forward * FireballSpeed;
        ////Destroy(fireball, FireballTime);
    }
}
