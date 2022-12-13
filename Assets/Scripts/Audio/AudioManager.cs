using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(AudioSource)) ]
public class AudioManager : MonoBehaviour
{
    [Header("Audio Events")]
    public AudioEvent hitMark;

    public AudioSource source;

    private void Start()
    {
       source = GetComponent<AudioSource>();
    }

    public void PlayHitMark()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            hitMark.Play(source);
        }
    }

}
