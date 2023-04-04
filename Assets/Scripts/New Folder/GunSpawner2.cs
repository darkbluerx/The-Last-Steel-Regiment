using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner2 : MonoBehaviour
{
    [SerializeField] GameObject[] guns;

    [SerializeField] enum SelectedGun { Pistol, Machinegun, Rifle };
    [Space]
    [SerializeField] SelectedGun selectedGun;
    [SerializeField] Dictionary<SelectedGun, GameObject> gunList;
  
    void Start()
    {
        SpawnTest();
    }

  
    void Update()
    {
        
    }

    public void SpawnTest()
    {
        Dictionary<SelectedGun, GameObject> list = new Dictionary<SelectedGun, GameObject>();

        GameObject Pistol = new GameObject("Pistol");


    }

    public void SpawnDitionary()
    {
        if(gunList != null)
        {

        }

        //GameObject gunObject = guns[SelectedGun];
        //Instantiate(gunObject, gunPosition.position + gunDistance, Quaternion.identity);
    }

}
