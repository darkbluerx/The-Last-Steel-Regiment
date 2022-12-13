using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShooting : MonoBehaviour
{
    public EnemyStats enemyStats;
    public GunStatsSO gunStats;
    

    [SerializeField] Transform barrelPoint;
    [SerializeField] GameObject bullet;

    private float m_CurrentLaunchForce;
    private bool m_Fired;
    private float nextFireTime;

    Rigidbody2D m_Rigidbody;


    //tee raycast bool, jos raycast osuu pelaajan vihollinen ampuu. t‰m‰ on luultavasti hyv‰ tehd‰ AttackActionissa
    //jos circlecast ja raycast osuu vihollinen ampuu

    bool chasePlayer;

    //private void OnEnable()
    //{
    //    chasePlayer = true;
    //}

    private void Update()
    {
       // ShootPlayer(m_CurrentLaunchForce, 1);
        if(Input.GetKeyDown(KeyCode.Space)) ShootPlayer(m_CurrentLaunchForce, 1);

        // LookPlayer();
    }

    //private void LookPlayer() //k‰‰nt‰‰ agentin pelaajaa kohti
    //{     
    //    float targetAngle;

    //    // Mathf.Atan2 = Tan x/y
    //    Vector3 targetDirection = chaseTarget.transform.position - transform.position;
    //    targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

    //    controller.rb2d.MoveRotation(Mathf.LerpAngle(controller.rb2d.rotation, targetAngle, 3 * Time.deltaTime));
    //}

    public void ShootPlayer(float launchForce, float fireRate)
    {

        //laita ampumaan pelaajaa kohti

        if (Time.time <= nextFireTime) return;

        nextFireTime = Time.time + fireRate;
        m_Fired = true;

        //Rigidbody shellInstance =
        //    Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
        //shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

        //Make spread
        Vector3 bulletSpread = new Vector3(0, Random.Range(-gunStats.spread, gunStats.spread));

        //Instantuate bullet
            GameObject currentBullet = Instantiate(bullet, barrelPoint.position, Quaternion.Euler(0, 0, 0));

        //Add force &make spread
            currentBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * gunStats.bulletSpeed + bulletSpread, ForceMode2D.Impulse);

        //Activated bullet
            if (currentBullet.GetComponent<Bullet>()) currentBullet.GetComponent<Bullet>().bulletActivated = true;
    
        Destroy(currentBullet, enemyStats.attackRange);
    }




}
