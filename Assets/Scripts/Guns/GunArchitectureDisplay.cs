using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunArchitectureDisplay : MonoBehaviour
{
    [Header("Vedä tähän halutun aseen tiedot")]
    public GunArchitectureSO gunArchitecture;

    [Header("Gun")]
    public TMP_Text gunName;
    public Image gunPic;
    [Multiline(7)] public TMP_Text info;
    [Space]

    [Header("Muzzle")]
    public TMP_Text muzzleName;
    public Image muzzlePic;
    public GameObject muzzlePrefab;
    [Space]

    [Header("Bullet")]
    public TMP_Text bulletName;
    public Image bulletPic;
    public GameObject bulletPrefab;
    [Space]

    [Header("BulletLine"), Tooltip("Viiva/valojuova lähtee luodista ammuttaessa")]
    public TMP_Text bulletLineName;
    public Image bulletLinePic;

    [Header("Not coming soon")]
    [Tooltip("Aseen lisävarusteet")] public TMP_Text GunAccessories;
    public Image gunAccessories;
    //lisävarusteille oma scirtableobjektinsa

    private void Awake()
    {
        //Gun
        gunName = transform.Find("WeaponPanel/GunName").GetComponent<TextMeshProUGUI>();
        gunPic = transform.Find("WeaponPanel/GunImage").GetComponent<Image>();
    }

    private void Start()
    {
        //Gun
        // teksti = string
        gunName.text = gunArchitecture.gunName.ToString();
        gunPic.sprite = gunArchitecture.gunPic;
        //info.text = gunArchitecture.info;

        //Muzzle
        //muzzleName.text = gunArchitecture.muzzleName.ToString();
        //muzzlePic.sprite = gunArchitecture.muzzlePic;
        

        ////Bullet
        //bulletName.text = gunArchitecture.bulletName.ToString();
        //bulletPic.sprite = gunArchitecture.bulletPic;

        ////BulletLine
        //bulletLineName.text = gunArchitecture.bulletLineName.ToString();
        //bulletLinePic.sprite = gunArchitecture.bulletLinePic;

        //Aseen lisävarusteet
    }
}
