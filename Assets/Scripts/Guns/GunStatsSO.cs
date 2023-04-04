using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "GunStats", menuName = "Gun/GunStats")]

public class GunStatsSO : ScriptableObject
{
    //[Header("Gun type")]
    public enum GunType { handgun, submachinegun, rifle, machinegun };
    public GunType gunType;

    [Header("Gun Characteristics")]
    [Range(0, 100)] public float damage = 1f;
    [Range(1, 50)] public float bulledRange = 5f;
    [Range(0.1f, 20)] public float reloadTime = 0.5f;
    [Space]

    [Header("Magazine/Bullet parameters"), Tooltip("MiniumBulletSpeed = 10")]
    [Range(1, 50)] public float bulletSpeed = 10f;
    [Range(0, 3)] public int bulletPerTap = 1;
    [Range(1, 250)] public int magazineSize = 7;
    public int bulletShot;
    public int bulletLeft;
    [Space]

    [Range(0, 10), Tooltip("Aika laukausten v‰lill‰")] public float timeBetweenShots = 0.1f; //0,18
    [Range(0, 5), Tooltip("ShotResetTime")] public float timeBetweenShooting = 0.4f; //0,40
    [Range(0, 20)] public float spread = 0.23f; //0,23

    [Header("Not comig soon")]
    [Range(0, 10)] public float durability;
    [Range(0, 10)] public int weaponAccessoriesNumber;

    public GunStatsSO(GunStatsSO gunStats)
    {
        bulletSpeed = gunStats.bulletSpeed;
        bulletShot = gunStats.bulletShot;
        bulletPerTap = gunStats.bulletPerTap;   
    }
}

    //public static GunStatsSO GetCopy(GunStatsSO gunStats)//tehd‰‰n kopio t‰st‰ classista, joka on jatkuvasti muistissa assateissa
    //{//t‰t‰ voidaan kutsua muualta sitten
    //    GunStatsSO coby = new GunStatsSO(gunStats);

    //    return coby;
    //}


