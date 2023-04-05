using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombatSystem.Core
{
    //you only create health variables and events
    public interface IDamageable
    {
        //void TakeDamage(int amount);

        //Player Base Stats/Sniper
        int playerHealth { get; }
        int playerMaxHealth { get; }

        event System.Action healthChanged;
        event System.Action maxHealthChanged;
    }
}
