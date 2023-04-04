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
    [Range(0, 100)] public float damage;
    [Range(1, 50)] public float bulledRange;
    [Range(0.1f, 20)] public float reloadTime;
    [Space]

    [Header("Magazine/Bullet parameters"), Tooltip("MiniumBulletSpeed = 10")]
    [Range(1, 50)] public float bulletSpeed;
    [Range(0, 3)] public int bulletPerTap;
    [Range(1, 250)] public int magazineSize;
    public int bulletShot;
    public int bulletLeft;
    [Space]

    [Range(0, 10), Tooltip("Aika laukausten välillä")] public float timeBetweenShots; //0,18f
    [Range(0, 5), Tooltip("ShotResetTime")] public float timeBetweenShooting; //0,40f
    [Range(0, 20)] public float spread; //0,23f

    //[Header("Not coming soon")]
    //[Range(0, 10)] public float durability;
    //[Range(0, 10)] public int weaponAccessoriesNumber; 
}
