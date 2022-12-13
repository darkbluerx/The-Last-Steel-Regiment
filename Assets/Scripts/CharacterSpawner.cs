using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    [Serializable]
    public class CharacterSpawner
    {
        public Color m_CharacterColor;                           // This is the color this tank will be tinted.
        public Transform m_Spawnpoint;                           // The position and direction the tank will have when it spawns.

        [HideInInspector] public int m_PlayerNumber;             // This specifies which player this the manager for.
        [HideInInspector] public string m_ColoredPlayerText;     // A string that represents the player with their number colored to match their tank.
        [HideInInspector] public GameObject m_Instance;          // A reference to the instance of the character when it is created.

        [HideInInspector] public List<GameObject> m_WayPointList;

        TopDownController m_Controller;
        EnemyShooting m_EnemyShooting;                          // Reference to tank's shooting script, used to disable and enable control.
        GameObject m_CanvasGameObject;                          // Used to disable the world space UI during the Starting and Ending phases of each round.
        StateController m_StateController;                      // Reference to the StateController for AIs


        public void SetupAI(List<Transform> wayPointList)
        {
            m_StateController = m_Instance.GetComponent<StateController>();
            m_StateController.SetupAI(true, wayPointList);

            m_EnemyShooting = m_Instance.GetComponent<EnemyShooting>();
            //m_EnemyShooting.m_PlayerNumber = m_PlayerNumber;

           // m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;
            m_ColoredPlayerText = "<color=#>" + ColorUtility.ToHtmlStringRGB(m_CharacterColor) + ">PLAYER " + m_PlayerNumber + "</color>";

            // Get all of the renderers of the character.
            MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer>();

            // Go through all the renderers...
            for (int i = 0; i < renderers.Length; i++)
            {
                // ... set their material color to the color specific to this character.
                renderers[i].material.color = m_CharacterColor;
            }
        }

        public void SetupPlayer()
        {
            // Get references to the components.
            
            //m_Controller = m_Instance.GetComponent<TopDownController>();
            m_EnemyShooting = m_Instance.GetComponent<EnemyShooting>();
            //m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;

           // m_Controller.m_PlayerNumber = m_PlayerNumber;
           // m_EnemyShooting.m_PlayerNumber = m_PlayerNumber;

            m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_CharacterColor) + ">PLAYER" + m_PlayerNumber + "</color>";

            MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer>();

            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.color = m_CharacterColor;
            }
        }

        public void DisableControl()
        {
            //if (m_Controller != null) m_Controller.enabled = false;
            if(m_StateController != null) m_StateController.enabled = false;

            m_EnemyShooting.enabled = false;
            m_CanvasGameObject.SetActive(false);
        }

        public void EnableControl()
        {
            //if (m_Controller != null) m_Controller.enabled = true;
            if (m_StateController != null) m_StateController.enabled = true;

            m_EnemyShooting.enabled = true;
            m_CanvasGameObject.SetActive(true);
        }

        public void Reset()
        {
            m_Instance.transform.position = m_Spawnpoint.position;
            m_Instance.transform.rotation = m_Spawnpoint.rotation;

            m_Instance.SetActive(false);
            m_Instance.SetActive(true);
        }
    }
}
