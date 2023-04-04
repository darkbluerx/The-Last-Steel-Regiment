using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpController2D : MonoBehaviour
{
    [SerializeField] Gun gunScript;
    [Space]

    [Header("Player")]
    [SerializeField] Transform player;   
    [SerializeField] Transform playerWeaponHandler;
    [Space]

    [Header("Gun")]
    [SerializeField] Transform barrelPoint;
    [SerializeField] BoxCollider2D gunColl;
    [SerializeField] float pickUpRange = 2f;
    [Space]

    public bool equipped;
    public static bool slotFull;

    // aseen nappaus n‰pp‰imen ja sijainnin mukaan jolloin ei tarvita Boxcollider ja  updatea
    //PickUp() ja Drop() tehd‰‰n eventeill‰

    private void Awake()
    {
       player = GameObject.Find("Player").GetComponent<Transform>();
       playerWeaponHandler = GameObject.Find("WeaponHandling").GetComponent<Transform>();   
    }

    void Start()
    {
        //Setup
        if (!equipped)
        {
            gunScript.enabled = false;          
            gunColl.isTrigger = false;
        }
        if (equipped)
        {
            gunScript.enabled = true;           
            gunColl.isTrigger = false;
            slotFull = true;
        }
    }

    void Update()
    {
        //Check if player is the range and "E" is pressed
        Vector3 distangeToPlayer = player.position - transform.position;
        if (!equipped && distangeToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUpPlayer();
    
        //Drop if equipped and "Q" is pressed
        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    private void PickUpPlayer()
    {
        equipped = true;
        slotFull = true;

        //Make weapon a child of the camera and move it to default position
        transform.SetParent(playerWeaponHandler);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //Make Rigibody kinematic and BoxCollider a trigger
        gunColl.isTrigger = true;

        //Enable script
        gunScript.enabled = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        //Set prant to null
        transform.SetParent(null);

        //Make Rigipody not kinematic and BoxCollider normal
        gunColl.isTrigger = false;

        //Disable script
        gunScript.enabled = false;
    }
}

