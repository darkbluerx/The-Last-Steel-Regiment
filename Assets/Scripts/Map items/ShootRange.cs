using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Net;
using System.Drawing;
using Unity.VisualScripting;

public class ShootRange : MonoBehaviour
{
    [SerializeField] Vector3 startPointA;
    [SerializeField] Vector3 endPointB;
    [Space]

    [SerializeField,Range(0.1f, 10f)] float moveSpeed = 1f;
    [Space]

    [Header("Show startPointA & endPointB distance")]
    //[SerializeField] float showDistance; //shows the distance between point a and b
    [Space]
    [SerializeField,Range(0.1f, 10f)] float transitionTime = 1f;

    IEnumerator Start()
    {
        //showDistance = Vector3.Distance(startPointA, endPointB);

        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, startPointA, endPointB));
            yield return StartCoroutine(MoveObject(transform, endPointB, startPointA));
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos)
    {     
        var i = 0.0f;

        while (i < transitionTime)
        {
            i += Time.deltaTime * moveSpeed;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
}