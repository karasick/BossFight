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

    private float CurrentHealthHitValue = 0;
    private float HitSpeed = 30;

    private float CurrentHealthRegenerationValue = 0;
    private float RegenerationSpeed = 30;

    private float HPAfterChange;

    // Start is called before the first frame update
    void Start()
    {
        CheckHealth();
        SetUpPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        HandleHealth();
    }


    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            TakeHealthHit(20);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            TakeHealthRegeneration(10);
        }
    }

    private void SetUpPlayer()
    {
        Profile.ActivePlayerState = PlayerState.Alive;
        Profile.CurrentHealth = Profile.MaxHealth;
        HPAfterChange = Profile.MaxHealth;
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

    private void HandleHealth()
    {
        CheckHealth();

        //Debug.Log(Profile.CurrentHealth);

        if (CurrentHealthRegenerationValue > 0)
        {
            Profile.CurrentHealth += Time.deltaTime * RegenerationSpeed;
            CurrentHealthRegenerationValue -= Time.deltaTime * RegenerationSpeed;
        }
        else if (CurrentHealthRegenerationValue < 0)
        {
            CurrentHealthRegenerationValue = 0;
            Profile.CurrentHealth = HPAfterChange;
        }

        if (CurrentHealthHitValue > 0)
        {
            Profile.CurrentHealth -= Time.deltaTime * HitSpeed;
            CurrentHealthHitValue -= Time.deltaTime * HitSpeed;
        }
        else if (CurrentHealthHitValue < 0)
        {
            CurrentHealthHitValue = 0;
            Profile.CurrentHealth = HPAfterChange;
        }

        if(TimeBeforeRegeneration < Profile.RegenerationHealthSpeed)
        {
            TimeBeforeRegeneration += Time.deltaTime;
        }
        else
        {
            if (Profile.CurrentHealth < Profile.MaxHealth)
            {
                TakeHealthRegeneration(Profile.RegenerationHealthPoints);

                //Debug.Log("auto_regen" + Profile.CurrentHealth);
            }

            TimeBeforeRegeneration = 0;
        }

        if(Profile.CurrentHealth > Profile.MaxHealth)
        {
            Profile.CurrentHealth = Profile.MaxHealth;
            HPAfterChange = Profile.MaxHealth;
        }
    }


    public void TakeHealthHit(float hitValue)
    {
        if(Profile.CurrentHealth > 0)
        {
            if(CurrentHealthRegenerationValue > hitValue)
            {
                CurrentHealthRegenerationValue -= hitValue;
                HPAfterChange -= hitValue;
            }
            else if(CurrentHealthRegenerationValue < hitValue && CurrentHealthRegenerationValue != 0)
            {
                CurrentHealthHitValue += hitValue - CurrentHealthRegenerationValue;
                HPAfterChange -= hitValue;
                CurrentHealthRegenerationValue = 0;
            }
            else
            {
                CurrentHealthHitValue += hitValue;
                HPAfterChange -= hitValue;
            }
        }

        //Debug.Log("hit" + HPAfterChange);
    }


    public void TakeHealthRegeneration(float regenerationValue)
    {
        if (Profile.CurrentHealth < Profile.MaxHealth)
        {
            if(CurrentHealthHitValue > regenerationValue)
            {
                CurrentHealthHitValue -= regenerationValue;
                HPAfterChange += regenerationValue;
            }
            else if(CurrentHealthHitValue < regenerationValue && CurrentHealthHitValue != 0)
            {
                CurrentHealthRegenerationValue += regenerationValue - CurrentHealthHitValue;
                HPAfterChange += regenerationValue;
                CurrentHealthHitValue = 0;
            }
            else
            {
                CurrentHealthRegenerationValue += regenerationValue;
                HPAfterChange += regenerationValue;
            }
        }

        //Debug.Log("regen" + HPAfterChange);
    }


    private void HitPlayer()
    {
        
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
