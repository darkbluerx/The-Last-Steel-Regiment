using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserSight : MonoBehaviour
{
    LineRenderer lr;
    //[SerializeField] Transform barrelStartPoint;
    //[SerializeField] Vector3 barrelEndPoint;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.up, out hit)) 
        {
            if (hit.collider)
            {
                lr.SetPosition(1, new Vector3(hit.distance, 0,0));
            }
            else
            {
                lr.SetPosition(1, new Vector3(200, 0,0));
            }
        }
     
    }
}