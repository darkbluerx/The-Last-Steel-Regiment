using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOptions : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;

    void Start()
    {
        settingsPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsPanel.activeInHierarchy)
            {
                settingsPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                settingsPanel.SetActive(true);
            }
        }
    }
}
