using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    Image pic;
    [SerializeField] Color color;
    
    [SerializeField] Sprite currentCrosshair;
    [SerializeField] List<Sprite>crosshairList;

    [SerializeField] AudioEvent weaponPickUp;
    [SerializeField] AudioSource audioSource;

    bool playAudio;

    private void OnEnable()
    {
        Cursor.visible = false;
    }

    private void Awake()
    {
        pic = GetComponent<Image>();
        pic.sprite = currentCrosshair;          
    }

    void Start()
    {
        Cursor.visible = false;
        pic.color = color;
        playAudio = true;
    }

    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void HangunCrosshair()
    {
        playAudio = false;
        weaponPickUp.Play(audioSource); //play "weapon pick up" sound
        currentCrosshair = crosshairList[0];
        pic.sprite = currentCrosshair;
        
    }

    public void SubmachineCrosshair()
    {
        playAudio = false;
        weaponPickUp.Play(audioSource);
        currentCrosshair = crosshairList[1];
        pic.sprite = currentCrosshair; 
    }

    public void RifleCrosshair()
    {
        playAudio = false;
        weaponPickUp.Play(audioSource);
        currentCrosshair = crosshairList[2];
        pic.sprite = currentCrosshair;
    }

    public void MachinegunCrosshair()
    {
        playAudio = false;
        weaponPickUp.Play(audioSource);
        currentCrosshair = crosshairList[3];
        pic.sprite = currentCrosshair;
    }
}
