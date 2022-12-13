using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float health = 100;
    private bool isDestroing;

    //public TimeManager timeManager;
   
    //[Header("TestButton P"), Tooltip("Voit vaihtaa näppäintä")]
    //public KeyCode PlayButton = KeyCode.Space;

    private void Update()
    {
        //if(Input.GetKeyDown(PlayButton)) StartCoroutine(DestroyObject());
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health < 0 && !isDestroing) StartCoroutine(DestroyObject());
    }

    private IEnumerator DestroyObject()
    {     
        //timeManager.DoSlowmotion();

        isDestroing = true;
        GetComponent<Renderer>().material.color = Color.blue;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }  
}
