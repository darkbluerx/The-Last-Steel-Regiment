using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//https://docs.unity3d.com/ScriptReference/BoxCollider-size.html

[RequireComponent(typeof(BoxCollider2D),typeof (SpriteRenderer))]
public class PlayerTeleport : MonoBehaviour
{
     BoxCollider2D collider;
    //[SerializeField,Range(1,20)] float scaleX, scaleY, scaleZ; //tee myöhemmin PlayerPrefs tallennus jos näet tarpeelliseksi

    [SerializeField] GameObject currentTeleport;
   
    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();       
    }

    void Update()
    {
        //ChangeCollisionSize();
        TeleportDestination();
    }

    private void ChangeCollisionSize()
    {
        //collider.size = new Vector3(scaleX, scaleY, scaleZ);
    }

    private void TeleportDestination()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(currentTeleport != null)
            {
                transform.position = currentTeleport.GetComponent<Teleporter>().GetDestination().position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleport = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if(collision.gameObject == currentTeleport)
            {
                currentTeleport = null;
            }
        }
    }
}
