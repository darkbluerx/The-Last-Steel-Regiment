using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    //[RequireComponent(typeof(AudioSource))]
    //public class GameManager : MonoBehaviour
    //{
    //    public GameObject[] m_CharacterPrefabs;
    //    public CharacterSpawner[] m_Characters;
    //    public List<Transform> wayPointsForAI;

    //    void Start()
    //    {
    //        SpawnAllCharacters();
    //        EnableCharacterControl(); //asettaa liikkumiscontrollin
    //    }

    //    private void SpawnAllCharacters()
    //    {
    //        //Manually setup the player at index zero in the tanks array
    //        m_Characters[0].m_Instance =
    //            Instantiate(m_CharacterPrefabs[0], m_Characters[0].m_Spawnpoint.position, m_Characters[0].m_Spawnpoint.rotation) as GameObject;
    //        m_Characters[0].m_PlayerNumber = 1;
    //        m_Characters[0].SetupPlayer();

    //        for (int i = 0; i < m_Characters.Length; i++)
    //        {
    //            m_Characters[0].m_Instance =
    //                Instantiate(m_CharacterPrefabs[i], m_Characters[i].m_Spawnpoint.position, m_Characters[i].m_Spawnpoint.rotation) as GameObject;
    //            m_Characters[i].m_PlayerNumber = i + 1;
    //            m_Characters[i].SetupAI(wayPointsForAI);
    //        }
    //    }

    //    private void ResetAllCharacters()
    //    {
    //        for (int i = 0; i < m_Characters.Length; i++)
    //        {
    //           m_Characters[i].Reset();
    //        }
    //    }

    //    private void EnableCharacterControl()
    //    {
    //        for (int i = 0; i < m_Characters.Length; i++)
    //        {
    //            m_Characters[i].EnableControl();
    //        }
    //    }

    //    private void DisableChracterControl() //tätä voidaan kutsua kun peli on ohitse
    //    {
    //        for (int i = 0; i < m_Characters.Length; i++)
    //        {
    //            m_Characters[i].DisableControl();
    //        }
    //    }
    //}
}

