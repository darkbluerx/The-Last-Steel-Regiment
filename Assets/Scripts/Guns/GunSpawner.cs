using System.Collections.Generic;
using UnityEngine;

public class OldGunSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] fixedGunList;
    [SerializeField] Transform[] fixedGunPosition;
    [Space]
    [Space]
    //[SerializeField] GameObject[] gunList;

    //public static GunSpawner Instance = null;
    public List<GunList> gunList = new List<GunList>();

    [Header("Location next to the Player")]
    [SerializeField] Transform gunPosition;
    [SerializeField] Vector3 gunDistance = new Vector3(3, 0, 0);

    //[Header("Select your gun")]
    public enum SelectedGun {Pistol, Machinegun, Rifle};
    [Space]
    public SelectedGun selectedGun;
    //[SerializeField] Dictionary<SelectedGun, GameObject> selectedGunList;


    private void Start()
    {
        FixedSpawnGun();
        //SpawnDitionary();
    }

    //tuo yhden aseen kerrallaan
    public void SpawnGun()
    {
        switch (selectedGun)
        {
            //case SelectedGun.Pistol:
            //    Instantiate(gunList[selectedGun], gunPosition.position + gunDistance, Quaternion.identity); break;
            //case SelectedGun.Machinegun:
            //    Instantiate(gunList[1], gunPosition.position + gunDistance * 1.5f, Quaternion.identity); break;
            //case SelectedGun.Rifle:
            //    Instantiate(gunList[2], gunPosition.position + gunDistance * 2, Quaternion.identity); break;
        }
    }

    //tuo kaikki aseet kerralla kentt‰‰n fixedGunPosition[] kohtiin
    public void FixedSpawnGun()
    {
        for (int i = 0; i < fixedGunList.Length; i++)
        {         
            Instantiate(fixedGunList[i], fixedGunPosition[i].position, Quaternion.identity);          
        }
    }

    //testu
    //public void SpawnDitionary()
    //{
    //    GameObject gunObject = selectedGunList[selectedGun];
    //    Instantiate(gunObject, gunPosition.position + gunDistance, Quaternion.identity);
    //}

}
