using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombatSystem.Core
{
    public interface IWeaponStats
    {
        int ammo { get; }
        int maxAmmo { get; }

        event System.Action ammoChanged;
        event System.Action maxAmmoChanged;
    }
}
