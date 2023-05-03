using CombatSystem.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour //IDamageable
{
    [SerializeField] int m_health = 100;
    //[SerializeField] int m_maxHealth = 100;

    bool isDestroing;

    public void TakeDamage(int amount)
    {
        m_health -= amount;
        if (m_health < 0 && !isDestroing) StartCoroutine(DestroyObject());
    }

    private IEnumerator DestroyObject()
    {  
        isDestroing = true;
        GetComponent<Renderer>().material.color = Color.blue;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}

