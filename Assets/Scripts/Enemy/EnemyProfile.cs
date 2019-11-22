using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState { Alive, Dead };

[CreateAssetMenu(menuName = "Enemy Profile")]
public class EnemyProfile : ScriptableObject
{
    public EnemyState ActivePlayerState;

    public int Level;

    public int ExpToGain;

    public float MaxHealth;

    public float CurrentHealth;

    public float RegenerationHealthPoints;

    public float RegenerationHealthSpeed;

    public float AttackSpeedPerSec;

    public float AttackDamage;
}
