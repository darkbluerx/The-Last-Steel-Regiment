using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
   [SerializeField] AudioManager audioManager;

    public KeyCode playSound1 = KeyCode.I;
    public KeyCode playSound2 = KeyCode.O;
    public KeyCode playSound3 = KeyCode.P;

    public KeyCode playSound4 = KeyCode.K;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(playSound1)) audioManager.PlaySound1();
        //if (Input.GetKeyDown(playSound2)) audioManager.PlaySound2();
        //if (Input.GetKeyDown(playSound3)) audioManager.PlaySound3();

        //if (Input.GetKeyDown(playSound4)) audioManager.PlayListaAudio();
    }
}
