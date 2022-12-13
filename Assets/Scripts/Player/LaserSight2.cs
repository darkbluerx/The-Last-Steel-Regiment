using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserSight2 : MonoBehaviour
{
    LineRenderer lr;
    [SerializeField] Transform pointA;
    [SerializeField] Vector3 pointB;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(pointA.position, pointA.right, 10);
        if (hit)
        {
            pointB = hit.point;
        }
        else
        {
            pointB = pointA.transform.position + pointA.right * 10;
        }

        lr.SetPosition(0, pointA.position);
        lr.SetPosition(1, pointB);
    }
}

