using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

//https://www.dropbox.com/s/g077hpelcdnjyqm/GunSystem.cs?dl=0

public class PlayerShoot : MonoBehaviour
{//ampuminen hiiren klikki‰ pohjaan painattaessa

    //public TestAudio testAudio;
    //[SerializeField] AudioEvent shoot;

    public AudioEvent shoot;
    public AudioSource audioSource;

    //tee enumeilla raycastshoot ja projictileshoot

    [SerializeField] Transform barrelPoint;
    [SerializeField] Camera fpsCam;
    //[SerializeField] Vector3 spread;
    //Vector3 targetPoint;

    [Header("Gun Stats")]
    [SerializeField][Range(-3,3)] float spread;
    [SerializeField] float upwardForce;
    [SerializeField] float range;
    [Space]

    [Header("Recoil")]
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] float recoilForce;
    [Space]

    [Header("Magazine")]
    [SerializeField] int magazineSize = 30;
    [Space]

    [Header("Bullet parameters")]
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed = 20;
    [SerializeField] int bulletShot;
    [SerializeField] int bulletPerTap;
    [SerializeField] int bulletLeft;
    [Space]

    [Header("Reload")]
    float reloadTime;
    [SerializeField] float timeBetweenShots;
    [SerializeField] float timeBetweenShooting;
    [Space]

    [Header("Bools")]
    public bool shooting;
    bool readyToShoot;
    [SerializeField] bool allowButtonHold = true;
    bool allowInvoke = true;
    bool reloading; //
    readonly public bool shootingEnabled = true;
    [Space]

    [Header("Test")]
    RaycastHit rayHit;
    [SerializeField] int maxDistance = 10;
    public LayerMask layerMask;

    // RaycastHit hit;
    //Vector3 targetPoint1;

    private void Start()
    {
        bulletLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        CheckUsersInput();
        //siirr‰ t‰m‰ UI sciptiin
        //text.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);

        //test
        
        //Debug.DrawRay(barrelPoint.transform.position, transform.right * maxDistance, Color.green);

        if (Physics.Raycast(barrelPoint.transform.position, transform.right, out rayHit, maxDistance, layerMask))
        {
            print(rayHit.transform.name);
        }
    }

    public void CheckUsersInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKey(KeyCode.R) && bulletLeft < magazineSize && !reloading) Reload();

        if (readyToShoot && shooting && !reloading && bulletLeft > 0) 
        {
            bulletShot = bulletPerTap;
            Shoot();
        }
    }

    private void Shoot()
    {
       

        if (!shootingEnabled) return;

        readyToShoot = false;
        //‰‰ni
        shoot.Play(audioSource);

        //3d spread

        //Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        //RaycastHit hit;
        //Vector3 targetPoint;
        //if (Physics.Raycast(ray, out hit))
        //{
        //    targetPoint = hit.point;

        //}
        //else targetPoint = ray.GetPoint(75);

        //Vector3 directionWithSpread2 = targetPoint - barrelPoint.position;
        //float x = Random.Range(-spread, spread);
        //float y = Random.Range(-spread, spread);
        //float z = Random.Range(-spread, spread);

        //Vector3 directionWithSpread1 = mouseDirection + new Vector3(x, y, 0);

        //bullet.transform.position = new Vector3(Random.Range(barrelPoint.transform.position.x - range, barrelPoint.transform.position.x + range), barrelPoint.transform.position.y);
        Vector3 bulletSpread = new Vector3(0, Random.Range(-spread, spread));
        GameObject currentBullet = Instantiate(bullet, barrelPoint.transform.position + bulletSpread , Quaternion.Euler(0,0,0));
        //currentBullet.transform.right = directionWithSpread1.normalized;

        currentBullet.GetComponent<Rigidbody2D>().AddForce(barrelPoint.transform.right * bulletSpeed, ForceMode2D.Impulse);
        //currentBullet.GetComponent<Rigidbody2D>().AddForce(fpsCam.transform.right * upwardForce, ForceMode2D.Impulse);

        bulletLeft--;
        bulletShot--;

        if (allowInvoke)
        {
            Invoke("ShotReset", timeBetweenShooting);
            allowInvoke = false;

            //playerRb.AddForce(-directionWithSpread1.normalized * recoilForce, ForceMode2D.Impulse);
        }

        if (bulletShot > 0 && bulletLeft > 0) Invoke("Shoot", timeBetweenShots);
    }

    private void ShotReset()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

   private void Reload()
   {
        reloading = true;
        Invoke("ReloadingFinished", reloadTime);
   }

    private void ReloadingFinished()
    {
        bulletLeft = magazineSize;
        reloading = false;
    }
}
