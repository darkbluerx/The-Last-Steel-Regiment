using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TestAudioManager : MonoBehaviour
{
    [Header("Audio Events")]
    [SerializeField] AudioEvent hitMark;
    [SerializeField] AudioEvent sound1;
    [SerializeField] AudioEvent sound2;
    [SerializeField] AudioEvent sound3;


    public List<AudioEvent> audioeventLista;

    AudioSource source;


    //monen objektin haku
    //https://docs.unity3d.com/ScriptReference/ScriptableObject.html
    // https://docs.unity3d.com/ScriptReference/Object.FindObjectsOfType.html
    //https://docs.unity3d.com/Manual/class-ScriptableObject.html
    //https://docs.unity3d.com/ScriptReference/AssetDatabase.FindAssets.html
    private void Start()
    {
        source = GetComponent<AudioSource>();

        //hakee audioeventin, mutta ei hae haluttua hitMark audioeventtiä
        hitMark = ScriptableObject.CreateInstance<AudioEvent>();
        // hitMark =Resources.Load("hitMark") as AudioEvent;

        print(hitMark);
    }

    public void PlaySound1()
    {
        //source.pitch = Random.Range(Pitch - (RandomizePitch / 2), Pitch + RandomizePitch / 2);
        sound1.Pitch = Random.Range(0.6f, 0.8f);
        sound1.Play(source);
    }

    public void PlaySound2()
    {
        sound2.Play(source);
    }

    public void PlaySound3()
    {
        sound3.Play(source);
    }

    public void PlayHitMark()
    {
        hitMark.Play(source);
    }


    public void PlayListaAudio()
    {
        if (sound1)
        {
            sound1.Play(source);
        }

        audioeventLista[0].Play(source);
    }






}
