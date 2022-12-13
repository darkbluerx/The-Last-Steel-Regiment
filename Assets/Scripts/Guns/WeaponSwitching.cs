using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    [SerializeField] int selectedWeapon = 0;


    void Start()
    {
        SelectWeapon();
    }

  
    void Update()
    {
        int previousSelectedWaepon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {                     
            if (selectedWeapon >= transform.childCount - 1) selectedWeapon = 0;
            else selectedWeapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0) selectedWeapon = transform.childCount -1;
            else selectedWeapon--;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 5)
        {
            selectedWeapon = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 6)
        {
            selectedWeapon = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 7)
        {
            selectedWeapon = 6;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 8)
        {
            selectedWeapon = 7;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 9)
        {
            selectedWeapon = 8;
        }

        if (previousSelectedWaepon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if(i == selectedWeapon) weapon.gameObject.SetActive(true);
            else weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
