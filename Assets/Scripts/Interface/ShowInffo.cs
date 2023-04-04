using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInffo : MonoBehaviour, IObservable
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") Debug.Log("Trigger toimii");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") Debug.Log("Collision toimii");
    }

    public string ShowDetail()
    {
        return "Pick up, press E";
       
    }

    public void Show()
    {
        Debug.Log("Pick up, press E");
    }
}
