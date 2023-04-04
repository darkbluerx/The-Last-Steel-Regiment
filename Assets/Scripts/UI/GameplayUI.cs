using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CombatSystem.UI
{
    public class GameplayUI : HealthUI //alaluokka
    {
        ProgressBar healthBar;
        VisualElement rootVisualElement;



        Label currentHealth;
        Label ammo;
        Label maxAmmo;

        //yliajetaan perityn luokan HealthUI OnEnable
        protected override void OnEnable()
        {
            base.OnEnable(); //kutsuu pohjaluokan OneEnablea (HealthUI)

            rootVisualElement = m_UIDokument.rootVisualElement;

            healthBar = rootVisualElement.Q<ProgressBar>("healthBar");
            healthBar.value = (float)m_Damageable.playerHealth / m_Damageable.playerMaxHealth;

            ammo = rootVisualElement.Q<Label>("currentAmmo");
            maxAmmo = rootVisualElement.Q<Label>("maxAmmo");

            currentHealth = rootVisualElement.Q<Label>("currentHealth");

            ammo.text = m_WeaponStats.ammo.ToString();
            maxAmmo.text = m_WeaponStats.maxAmmo.ToString();

            currentHealth.text = m_Damageable.playerHealth.ToString();
        }

        //muuteaan healtin arvoa, yliajetaan peritty abstraktiluokka (HealthUI)
        protected override void OnHealthChanged()
        {
            healthBar.value = (float)m_Damageable.playerHealth / m_Damageable.playerMaxHealth;

            ammo.text = m_WeaponStats.ammo.ToString();
            maxAmmo.text = m_WeaponStats.maxAmmo.ToString();
            currentHealth.text = m_Damageable.playerHealth.ToString();
        }

        protected override void OnMaxHealthChanged()
        {
            healthBar.value = (float)m_Damageable.playerHealth / m_Damageable.playerMaxHealth;

            if (m_Damageable.playerHealth > 0)
            {
                if (m_UIDokument.rootVisualElement.style.display == DisplayStyle.None) //ei n‰ytet‰ mit‰‰n
                {
                    m_UIDokument.rootVisualElement.style.display = DisplayStyle.Flex; //n‰ytet‰‰n
                }
            }
            else
            {
                m_UIDokument.rootVisualElement.style.display = DisplayStyle.None;
            }
        }
    }
}
