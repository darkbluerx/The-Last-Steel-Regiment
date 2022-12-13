using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(AudioSource))]
public class ProoAduioTest : MonoBehaviour
{
    [Header("Audio Events")]
    public AudioEvent sound1;
    public AudioEvent sound2;
    public AudioEvent sound3;

    public List<AudioEvent> audioeventLista;

    AudioSource source;

    private void Start()
    {
        sound1.name = "MP40";

        //sound1 = GetComponent<AudioEvent>() = new AudioEvent();

        //foreach (AudioEvent audioEvent in audioeventLista)
        //{
        //    audioEvent.GetComponent<>().color =
        //}


        //sound2 = GetComponent<AudioEvent>();
        //sound3 = GetComponent<AudioEvent>();

        source = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) sound1.Play(source); //haluun soittaa sound1
    }

    public void PlayListaAudio()
    {
        //Tapa 1
        //listassa on 3 audioeventtiä, mutta sen pitäisi soittaa vain sound1, jos löytyy audioeventListasta -> audioEvent.name == audioeventListasta
        foreach (AudioEvent audioEvent in audioeventLista)
        {
           // if (audioEvent.name == audioeventLista[])
            {
                //audioeventLista[audioEvent.name].Play(source);
                

                audioeventLista.Remove(audioEvent);
            }
        }

        ////Tapa 2
        //for (int i = 0; i < audioeventLista.Count; i++)
        //{
        //    //AudioEvent biisinNimi;
            
        //      if (AudioEvent. name == audioeventLista[i])
        //      {

        //      }
        //}
    }
}
