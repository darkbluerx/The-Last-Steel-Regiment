using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TestAudio : MonoBehaviour
{
    //listassa on monta audieventti‰
    //public List<AudioEvent> audioeventLista;
    public List<AudioEvent> audioeventLista = new List<AudioEvent>();

    AudioSource source;


    public List<string> audioNames = new List<string>() { "biisi1", "biisi2" };

    string biisi1 = "kovaBisi";


    //if

    private void Start()
    {
        source = GetComponent<AudioSource>();

        //audioNames = AudioEvent ;


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) PlayListaAudio(audioeventLista[0]);
        if (Input.GetKeyDown(KeyCode.B)) PlayListaAudio(audioeventLista[1]);
    }


    public void PlayListaAudio(AudioEvent audioEvent)
    {

        //Tapa 1
        //ei soita oikein ‰‰ni‰
        //foreach (AudioEvent audioEvent2 in audioeventLista)
        //{
        //    //audioeventLista[].Play(source);

        //    if (audioeventLista[0]) audioeventLista[0].Play(source);
        //    if (audioeventLista[1]) audioeventLista[1].Play(source);


        //}



        //for (string i = 0; i < audioeventLista.Count; i++)
        //{
        //    if (audioeventLista[i] = biisi1) audioeventLista[1].Play(source);
        //}



        //Tapa 2
        if (audioEvent == audioeventLista[0])
        {
            audioeventLista[0].Play(source);
        }
        if (audioEvent == audioeventLista[1])
        {
            audioeventLista[1].Play(source);
        }


        //Tapa 3 switch

    }

    //public void PlayListaAudio2(string[] biisilista)
    //{
    //    for (int i = 0; i < biisilista.Length; i++)
    //    {
    //        biisilista[0] = biisilista[i].ToString();
    //        biisilista[1] = biisilista[i].ToString();
    //    }


    //    //audioeventLista[0] = biisilista[0]{"sas" }


    //    //Tapa 1
    //    //ei soita oikein ‰‰ni‰
    //    foreach (AudioEvent audioEvent2 in audioeventLista)
    //    {
    //        //audioeventLista[].Play(source);

    //        int[] biisilista2 = new int[biisilista.Length];

    //        //biisilista2 = audioeventLista.[audioeventLista.Count];


    //        //biisilista2[0] = biisilista2[i].ToString();
    //        //biisilista2[0] = audioeventLista[0];


    //       // if (audioeventLista[0]) audioeventLista[0].Play(source);
    //        //if (audioeventLista[1]) audioeventLista[1].Play(source);


}






   //}
//}
