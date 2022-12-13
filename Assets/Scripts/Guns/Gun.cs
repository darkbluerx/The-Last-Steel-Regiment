using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class Gun : MonoBehaviour
{
    Bullet currentBullet;

    [SerializeField] GunStatsSO gunStats;
    [Space]
    public AudioEvent shootAudioEvent;
    public AudioEvent reloadEvent;
    public AudioSource audioSource;
    [Space]

    //tee enumeilla raycastshoot ja projictileshoot

    [Header("Gun")]
    [SerializeField] Transform barrelPoint;
    [SerializeField] GameObject bullet;
    //[Space]

    //[Header("Gun Shooting Mod")]
    [SerializeField] enum TriggerType { auto = 0, single = 1, burst = 2 };
    [SerializeField] TriggerType currentMode = TriggerType.auto;
    [Space]
    //recoil shakeCamera

    //public enum WeaponType {Raycast, Projectile };
    //public WeaponType weaponType = WeaponType.Projectile;

    //[Header("Bools")]

    public bool isAuto;
    public bool isSingle;
    public bool isBurst;
    [Space]
    [Space]

    public bool offSafety;
    bool readyToShoot;
    [SerializeField] bool allowButtonHold = true;
    bool allowInvoke = true;
    bool reloading;
    readonly public bool shootingEnabled = true;

    //public LayerMask layerMask;

    private void Awake()
    {
        
    }

    private void Start()
    {
        gunStats.bulletLeft = gunStats.magazineSize;
        readyToShoot = true;
        isAuto = true;
    }

    private void Update()
    {
        ChangeGunShootingMod();
        ShootButtonPressedDown();
        SingleShot();

        //siirr‰ t‰m‰ UI sciptiin
        //text.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
        //if (Input.GetKeyDown(KeyCode.T)) { ChangeGunShootingMod();}
       
        //if(currentMode == TriggerType.auto)
        //{

        //}

    }

    private void ChangeGunShootingMod()
    { 
        //esimerkki
        //if(currentMode == TriggerType.single)
       

        if (Input.GetKeyDown(KeyCode.F))
        {
            switch (currentMode)
            {
                case TriggerType.auto: currentMode = TriggerType.single;               
                    gunStats.bulletShot = gunStats.bulletPerTap;
                    isSingle = true;
                    isAuto = false;
                    ShootButtonPressedDown();
                    break;
       
                case TriggerType.single: currentMode = TriggerType.burst;
                    isAuto = false;
                    isBurst = true;
                    isSingle = false;
                    SingleShot();
                    break;

                case TriggerType.burst: currentMode = TriggerType.auto;
                    isAuto = true;
                    isSingle = false;
                    isBurst = false;
                    break;
            }
        }
    }

    private void ShootButtonPressedDown()
    {
        if (allowButtonHold) offSafety = Input.GetKey(KeyCode.Mouse0) && isAuto; //ammutaan nappulan ollessa pohjassa
        CheckUsersInput();
    }

    private void SingleShot()
    {
        offSafety = Input.GetKeyDown(KeyCode.Mouse0) && isSingle;//ammutaan kerran painattaessa
        CheckUsersInput();
    }

    private void CheckUsersInput()
    {
        if (Input.GetKey(KeyCode.R) && gunStats.bulletLeft < gunStats.magazineSize && !reloading) StartReload();

        if (readyToShoot && offSafety && !reloading && gunStats.bulletLeft > 0)
        {
            Shoot(1f);      
        }
    }

    private void Shoot(float firerate)
    {
        if (!shootingEnabled) return;

        readyToShoot = false;
        //Shoot Sound
        shootAudioEvent.Play(audioSource);

        //Make spread
        Vector3 bulletSpread = new Vector3(0, Random.Range(-gunStats.spread, gunStats.spread));

        //Instantuate bullet
        GameObject currentBullet = Instantiate(bullet, barrelPoint.position, Quaternion.Euler(0,0,0));

        //Add force & make spread
        currentBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * gunStats.bulletSpeed + bulletSpread, ForceMode2D.Impulse);

        //Activated bullet
        if (currentBullet.GetComponent<Bullet>()) currentBullet.GetComponent<Bullet>().bulletActivated = true;

        //Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        Destroy(currentBullet, gunStats.bulledRange);

        gunStats.bulletLeft--;
        gunStats.bulletShot--;

        if (allowInvoke)
        {
            Invoke("ShotReset", gunStats.timeBetweenShooting);
            allowInvoke = false;

            //playerRb.AddForce(-directionWithSpread1.normalized * recoilForce, ForceMode2D.Impulse);
        }

        if (gunStats.bulletShot > 0 && gunStats.bulletLeft > 0) Invoke("Shoot", gunStats.timeBetweenShots);
    }

    private void ShotReset()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void StartReload()
    {
        reloading = true;
        reloadEvent.Play(audioSource); //soitet‰‰n ‰‰ni
        Invoke("ReloadingFinished", gunStats.reloadTime);
    }

    private void ReloadingFinished()
    {
        gunStats.bulletLeft = gunStats.magazineSize;
        reloading = false;
    }
}

