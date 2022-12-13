using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float zAngleSpeed = 1f;

    private void FixedUpdate()
    {
        RotateGun();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DestroyObject(this);
        }
    }

    public void RotateGun()
    {
        gameObject.transform.Rotate(0, 0, zAngleSpeed + 3 * Time.deltaTime);
        //gameObject.SetActive(false);

    }


    //private void Awake()
    //{
    //    StartCoroutine(RotateMe(Vector3.back * 90, 0.8f));
    //}

    //IEnumerator RotateMe(Vector3 byAngles, float inTime)
    //{
    //    var fromAngle = transform.rotation;
    //    var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
    //    for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
    //    {
    //        transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
    //        yield return null;
    //    }
    //}

}
