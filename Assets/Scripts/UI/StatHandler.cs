using CombatSystem.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

namespace DefaltNamespace
{
    public class StatHandler : MonoBehaviour, IWeaponStats, IDamageable
    {
        [SerializeField] int m_health = 5;
        [SerializeField] int m_maxHealth = 5;

        [SerializeField] int m_ammo = 30;
        [SerializeField] int m_maxAmmo = 30;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_health--;
                m_ammo--;
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                m_health--;
            }

        }

        public int playerHealth 
        {
            get => m_health;
            set
            {
                //asetaan raja m_health 0- maxHealth välille
                m_health = Mathf.Clamp(value, 0, playerMaxHealth);
                healthChanged?.Invoke();
            }
        }

        public int playerMaxHealth
        {
            get => m_maxHealth;
            set
            {
                m_maxHealth = value;
                maxHealthChanged?.Invoke();
            }
        }

        public int ammo
        {
            get => m_ammo;
            set
            {
                m_ammo = value;
                ammoChanged?.Invoke();
            }
        }

        public int maxAmmo
        {
            get => m_maxAmmo;
            set
            {
                m_ammo = value;
                ammoChanged?.Invoke();
            }
        }

        public event System.Action ammoChanged;
        public event System.Action maxAmmoChanged;

        public event System.Action healthChanged;
        public event System.Action maxHealthChanged;
    }
}
