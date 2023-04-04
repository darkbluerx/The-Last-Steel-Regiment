using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    Rigidbody2D rb;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    public bool bulletActivated;

    private void Update()
    {
        if (!bulletActivated) return;   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {       
        if (!bulletActivated) return;
        //if (collision.gameObject.tag == "Obstacle") Destroy(bullet);
        if (collision.gameObject.tag == "Obstacle") rb.constraints = RigidbodyConstraints2D.FreezePosition;
        if (collision.gameObject.tag == "Bullet") rb.constraints = RigidbodyConstraints2D.FreezePosition;
        if (collision.gameObject.tag == "Enemy") Destroy(bullet);

        //väliaikaiksesti poissa
        //IDamageable iDamageable = collision.gameObject.GetComponent<IDamageable>();
        //if (iDamageable != null) iDamageable.TakeDamage(20);
    }
}
