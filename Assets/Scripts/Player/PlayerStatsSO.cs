using CombatSystem.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Player",menuName = "Player Stats")]
public class PlayerStatsSO : ScriptableObject
{
    public int testInt;

    //Player Base Stats/Sniper
    public int playerHealth { get; }
    public int playerMaxHealth { get; }
    public int playerCurrentStamina { get; }
    public int playerMaxStamina { get; }
    public int playerDmg { get; }
    public int playerRange { get; }
    public int playerSpread { get; }
    public int playerFirerate { get; }

    //Gameplay Stats
    public int currentXp { get; }
    public int currentFps { get; }

    //public event System.Action healthChanged;
    //event System.Action maxHealthChanged;

    event System.Action healthChanged;
    event System.Action maxHealthChanged;

    //Weapon Stats
}
