using UnityEngine;

[System.Serializable]
public class GunList
{
    public string gunName;
    public GameObject weaponPrefab;

   public GunList(string gunName, GameObject weaponPrefab)
   {
        this.gunName = gunName;
        this.weaponPrefab = weaponPrefab;
   }
}
