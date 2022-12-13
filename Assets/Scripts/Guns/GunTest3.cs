using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class GunTest3 : MonoBehaviour
{
    Bullet currentBullet;

    [SerializeField] GunStatsSO gunStats;
    [Space]
    public AudioEvent shootEvent;
    public AudioEvent reloadEvent;
    public AudioSource audioSource;
    [Space]

    //tee enumeilla raycastshoot ja projictileshoot

    [Header("Gun")]
    [SerializeField] Transform barrelPoint;
    [SerializeField] GameObject bullet;


    //[Header("Gun Shooting Mod")]
    [SerializeField] enum TriggerTypee { autoo = 0, singlee = 1, burstt = 2 };
    [SerializeField] TriggerTypee currentMode = TriggerTypee.autoo;

    //recoil shakeCamera

    //public enum WeaponType {Raycast, Projectile };
    //public WeaponType weaponType = WeaponType.Projectile;

    [Header("Bools")]
    public bool offSafety;
    bool readyToShoot;
    [SerializeField] bool allowButtonHold = true;
    bool allowInvoke = true;
    bool reloading; //
    readonly public bool shootingEnabled = true;

    //public LayerMask layerMask;

    private void Start()
    {
        gunStats.bulletLeft = gunStats.magazineSize;
        readyToShoot = true;    
    }

    private void Update()
    {
        ChangeGunShootingMod();
        ShootButtonPressedDown();
        SingleShot();

        //siirr‰ t‰m‰ UI sciptiin
        //text.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
        if (Input.GetKeyDown(KeyCode.L)) { ChangeGunShootingMod();}
    }

    private void ChangeGunShootingMod()
    {
            switch (currentMode)
            {
                case TriggerTypee.autoo: currentMode = TriggerTypee.singlee;
                    gunStats.bulletShot = gunStats.bulletPerTap;
                    break;

                case TriggerTypee.singlee: currentMode = TriggerTypee.burstt;
                    break;

                case TriggerTypee.burstt: currentMode = TriggerTypee.autoo;
                    break;
            }
    }

    private void ShootButtonPressedDown()
    {
        if (allowButtonHold) offSafety = Input.GetKey(KeyCode.Mouse0); //ammutaan nappulan ollessa pohjassa
        CheckUsersInput();
    }

    private void SingleShot()
    {
        offSafety = Input.GetKeyDown(KeyCode.Mouse0);//ammutaan kerran painattaessa
        CheckUsersInput();
    }

    private void CheckUsersInput()
    {
        if (Input.GetKey(KeyCode.R) && gunStats.bulletLeft < gunStats.magazineSize && !reloading) StartReload();

        if (readyToShoot && offSafety && !reloading && gunStats.bulletLeft > 0)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!shootingEnabled) return;

        readyToShoot = false;
        // shoot Sound
        shootEvent.Play(audioSource);

        //Make spread
        Vector3 bulletSpread = new Vector3(0, Random.Range(-gunStats.spread, gunStats.spread));

        //Instantuate bullet
        GameObject currentBullet = Instantiate(bullet, barrelPoint.position + bulletSpread, Quaternion.Euler(0, 0, 0));

        //Add force
        currentBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * gunStats.bulletSpeed, ForceMode2D.Impulse);

        //activated bullet
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

