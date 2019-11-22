using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {Alive, Dead};

[CreateAssetMenu(menuName = "Player Profile")]
public class PlayerProfile : ScriptableObject
{
    public PlayerState ActivePlayerState;

    public int Level;

    public int CurrentExp;

    public int ExpToLevelUp;

    public float MaxHealth;

    public float CurrentHealth;

    public float RegenerationHealthPoints;

    public float RegenerationHealthSpeed;

    public float AttackSpeedPerSec;

    public float AttackDamage;
}
