using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController3D : MonoBehaviour
{
    public Gun gunScript;
    public Rigidbody2D rb;
    public BoxCollider2D coll;
    public Transform player, gunContainer, fpsCom;

    [SerializeField] float pickUpRange;
    [SerializeField] float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    void Start()
    {
        //Setup
        if (!equipped)
        {
            gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            gunScript.enabled = true;
            rb.isKinematic = false;
            coll.isTrigger = false;
            slotFull = true;
        }
    }

    void Update()
    {
        //Check if player is the range and "E" is pressed
        Vector3 distangeToPlayer = player.position - transform.position;
        if (!equipped && distangeToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();

        //Drop if equipped amd "Q" is pressed
        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //Make weapon a child of the camera and move it to default position
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //Make Rigibody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        //Enable script
        gunScript.enabled = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;
        //gunStatsSO.bulletLeft = 0;

        //Set prant to null
        transform.SetParent(null);

        //Make Rigipody not kinematic and BoxCollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;

        //Gun carries momentum of player
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //AddForce
        rb.AddForce(fpsCom.forward * dropForwardForce, ForceMode2D.Impulse);
        rb.AddForce(fpsCom.up * dropForwardForce, ForceMode2D.Impulse);
        //Add random rotation
        //float random = Random.Range(-1f, 1f);
        //rb.AddTorque(new Vector3(random, random, 0) * 10);

        //Disable script
        gunScript.enabled = false;
    }
}
