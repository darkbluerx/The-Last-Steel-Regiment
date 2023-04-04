using CombatSystem.Core;
using DefaltNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CombatSystem.UI
{
    [RequireComponent(typeof(UIDocument))]

    //t‰m‰ luokka on abstrakti luokka, jotta voidaan luoda abstrakti "metodeja"
    //eventtien avuilla kutsutaan abstrakti "metodeja", mutta toiminnat tehd‰‰n muualla
    public abstract class HealthUI : MonoBehaviour //pohjauokka
    {
        // protected muuttujia voidaan k‰ytt‰‰ alaluokissa jotka periytyv‰t HealtUI
        protected UIDocument m_UIDokument;
        [SerializeField] protected GameObject m_Owner; //pelaaja
        protected IDamageable m_Damageable;
        protected IWeaponStats m_WeaponStats;




        protected void Awake()
        {
            m_UIDokument = GetComponent<UIDocument>();
            m_Damageable = m_Owner.GetComponent<IDamageable>();
            m_WeaponStats = m_Owner.GetComponent<IWeaponStats>();
        }

        //miksi k‰ytet‰‰n t‰ss‰ protected virtual? jotta t‰t‰ samaa metodia voidaan k‰ytt‰ uudestaan alaluokissa
        //OnEnable toimii kun t‰m‰ koodi menee p‰‰lle
        protected virtual void OnEnable()
        {
            //eveneteill‰ kutsutaan ainoastaan abstrakti "metodeita", ne eiv‰t tee toimintoja

            m_Damageable.healthChanged += OnHealthChanged;
            m_Damageable.maxHealthChanged += OnMaxHealthChanged;

            m_WeaponStats.ammoChanged += OnHealthChanged;
            m_WeaponStats.maxAmmoChanged += OnHealthChanged;
        }

        //OnDisable toimii kun t‰m‰ koodi menee pois p‰‰lt‰ ja se poistaa eventtien avulla abstrakti "metodit"
        protected virtual void OnDisable()
        {

            m_Damageable.healthChanged += OnHealthChanged;
            m_Damageable.maxHealthChanged += OnMaxHealthChanged;


            m_WeaponStats.ammoChanged -= OnHealthChanged;
            m_WeaponStats.maxAmmoChanged -= OnHealthChanged;
        }

        //abstrakti metodi, kutsutaan kun halutaan vaikuttaa maxhealth
        protected abstract void OnMaxHealthChanged();

        protected abstract void OnHealthChanged();

        protected virtual void OnValidate() //
        {
            if (m_Owner != null)
            {
                if (m_Owner.GetComponent<UIDocument>() != null)
                {
                    Debug.Log("The owner must iplement the IDamageable interface!");
                    m_Owner = null;
                }
            }
        }
    }
}
