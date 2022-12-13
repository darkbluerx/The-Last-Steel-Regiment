using System;
using System.Collections;
using System.Collections.Generic;
//using System.Runtime.Remoting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //[SerializeField] AmmonationType bulletType;

    //mieti vielä toteutusta, mutta periaate on: kun valitset thopsonin
    [SerializeField] GameObject waltherBullet;
    [SerializeField] GameObject MP40Bullet;

    //public enum BulletType { Walther_P38, MP40, Thompson };
    //public BulletType bulletType;

    readonly bool isWaltherP38Bullet; // or bullet_9mm
    readonly bool isMP40Bullet;
    readonly bool isThompsonBullet;

    public bool bulletActivated;

    private void Update()
    {
        if (!bulletActivated) return;

        if (isWaltherP38Bullet) InstantiateWaltherP38Bullet();
        if (isMP40Bullet) InstantiateMP40();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!bulletActivated) return;

        IDamageable iDamageable = collision.gameObject.GetComponent<IDamageable>();
        if (iDamageable != null) iDamageable.TakeDamage(20);
    }

    private void InstantiateWaltherP38Bullet()
    {
        if (waltherBullet != null)
        {
           Instantiate(waltherBullet, transform.right, Quaternion.identity);
        }
    }

    private void InstantiateMP40()
    {
        if (MP40Bullet != null)
        {
            Instantiate(MP40Bullet, transform.right, Quaternion.identity);
        }
    }
}
