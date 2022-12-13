using UnityEngine;
using TMPro;

[System.Serializable]
[CreateAssetMenu(fileName = "Gun", menuName = "Gun/GunArchitectureS")]

public class GunArchitectureSO : ScriptableObject
{
    [Header("Gun")]
    public string gunName;
    public Sprite gunPic;
    [Multiline(7)] public string info;
    [Space]

    [Header("Muzzle")]
    public string muzzleName;
    public Sprite muzzlePic;
    public GameObject muzzlePrefab;
    [Space]

    [Header("Bullet")]
    public GameObject bulletPrefab;
    public string bulletName;
    public Sprite bulletPic;
    [Space]

    [Header("BulletLine"),Tooltip("Viiva/valojuova l�htee luodista ammuttaessa")]
    public string bulletLineName;
    public Sprite bulletLinePic;

    [Header("Not coming soon")]
    [Tooltip("Aseen lis�varusteet")] public string GunAccessories;
    public Sprite gunAccessories;
    //lis�varusteille oma scirtableobjektinsa
}
