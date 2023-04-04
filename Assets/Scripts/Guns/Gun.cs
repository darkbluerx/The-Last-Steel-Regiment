using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.Events;
using UnityEditor;

public class Gun : MonoBehaviour
{
    [Header("Change the crosshair")]
    [SerializeField] UnityEvent crosshairEvent;
    [Space]

    [Header("Weapon attributes")]
    [SerializeField] GunStatsSO gunStats;
    [Space]

    [Header("Sounds")]
    public AudioEvent shootAudioEvent;
    public AudioEvent reloadAudioEvent;
    public AudioEvent weaponPickUp;
    public AudioSource audioSource;
    [Space]

    [Header("Gun parts")]
    [SerializeField] Transform barrelPoint;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject shell;

    //[Header("Shooting Mode")]
    [SerializeField] enum TriggerType { auto = 0, single = 1, burst = 2 };
    [SerializeField] TriggerType shootingMode; //= TriggerType.auto;
    [Space]
    //recoil shakeCamera

    //public enum WeaponType {Raycast, Projectile };
    //public WeaponType weaponType = WeaponType.Projectile;

    //[Header("Bools")]
    bool isAuto;
    bool isSingle;
    bool isBurst;
  
    public bool offSafety;
    bool readyToShoot;
    [SerializeField] bool allowButtonHold = true;
    bool allowInvoke = true;
    bool reloading;
    readonly public bool shootingEnabled = true;

    private void Awake()
    {
       audioSource = GameObject.Find("Player").GetComponent<AudioSource>();
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
        if(isAuto)ShootButtonPressedDown();
        if(isSingle)SingleShot();
    }

    private void OnEnable()
    {
        //Activates the correct crosshair based on the weapon's atributes
        Invoke("Crosshair",0.1f);
    }

    public void Crosshair()
    {
        if (gunStats.gunType == GunStatsSO.GunType.handgun)
        {
            crosshairEvent?.Invoke();
        }
        if (gunStats.gunType == GunStatsSO.GunType.submachinegun)
        {
            crosshairEvent?.Invoke();
        }
        if (gunStats.gunType == GunStatsSO.GunType.rifle)
        {
            crosshairEvent?.Invoke();
        }
        if (gunStats.gunType == GunStatsSO.GunType.machinegun)
        {
            crosshairEvent?.Invoke();
        }
    }

    private void ChangeGunShootingMod()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            switch (shootingMode)
            {
                case TriggerType.auto: shootingMode = TriggerType.single;
                    gunStats.bulletShot = gunStats.bulletPerTap;
                    isSingle = true;
                    isAuto = false;
                    //isBurst = false;
                    break;

                case TriggerType.single:
                    shootingMode = TriggerType.burst; // Is not installed
                    isAuto = true;
                    isBurst = true;
                    isSingle = false;
                    break;

                case TriggerType.burst:
                    shootingMode = TriggerType.auto;
                    isAuto = true;
                    isSingle = false;
                    //isBurst = false;
                    break;
            }
        }
    }

    private void ShootButtonPressedDown()
    {
        if (allowButtonHold) offSafety = Input.GetKey(KeyCode.Mouse0); //&& isAuto; //ammutaan nappulan ollessa pohjassa
        CheckUsersInput();
    }

    public void SingleShot()
    {
        offSafety = Input.GetKeyDown(KeyCode.Mouse0); //&& isSingle;//ammutaan kerran painattaessa
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
        Vector3 bulletSpread = new Vector3(Random.Range(-gunStats.spread, gunStats.spread),0,0);

        //Instantiate bullet
        GameObject currentBullet = Instantiate(bullet, barrelPoint.position, Quaternion.Euler(0,0,-90));

        //Instantiate shell
        GameObject currentShell = Instantiate(shell, (barrelPoint.position) - transform.right * Random.Range(0.5f,1), bullet.transform.rotation);
        
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
        reloadAudioEvent.Play(audioSource); // Play reload sound
        Invoke("ReloadingFinished", gunStats.reloadTime);
    }

    private void ReloadingFinished()
    {
        gunStats.bulletLeft = gunStats.magazineSize;
        reloading = false;
    }
}

