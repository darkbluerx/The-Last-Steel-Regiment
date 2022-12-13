using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    bool buttonPressed = false;
    [SerializeField] GameEvent buttonPressedEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(buttonPressed == false)
        {
            Debug.Log(buttonPressed);
            buttonPressedEvent.Raise();
        }
    }
}
