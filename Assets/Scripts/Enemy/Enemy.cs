using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected GameSession GameSession;

    public EnemyProfile Profile;

    private float TimeBeforeRegeneration = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetUpEnemy();
        CheckHealth();
    }

    // Update is called once per frame
    void Update()
    {
        RegenerateHealth();
    }

    private void SetUpEnemy()
    {
        Profile.CurrentHealth = Profile.MaxHealth;
    }

    private void CheckHealth()
    {

        if (Profile.CurrentHealth <= 0)
        {
            Profile.ActivePlayerState = EnemyState.Dead;

            GameSession.GiveExpToPlayer(Profile.ExpToGain);

            Destroy(gameObject);
        }
        else
        {
            Profile.ActivePlayerState = EnemyState.Alive;
        }
    }

    private void RegenerateHealth()
    {
        if (Profile.ActivePlayerState == EnemyState.Alive)
        {
            CheckHealth();
        }

        //Debug.Log(Profile.CurrentHealth);

        if (TimeBeforeRegeneration < Profile.RegenerationHealthSpeed)
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

    private void SetHealthHit(float value)
    {
        Profile.CurrentHealth -= value;
    }

    private void SetHealthRegenerate(float value)
    {
        Profile.CurrentHealth += value;
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(Profile.CurrentHealth);

        if (other.gameObject.name == "FireBall(Clone)")
        {
            SetHealthHit(GameSession.GetPlayerAttackDamage());
        }
    }
}
