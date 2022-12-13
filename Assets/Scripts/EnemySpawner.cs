using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [Header("List of different types of enemies")]
    [Tooltip("Choose the enemies you want")]
    public GameObject[] enemyPrefabs;

    [Header("Decide the number of enemies")]
    [SerializeField, Range(1, 4)] int enemyNumbers;
    [Space]

    [Header("Select enemies spawn locations")]
    [SerializeField] Transform[] spawnPoints;
    [Space]

    [Header("List of Enemies")]
    public GameObject[] enemies;
    [Space]
    [Space]

    [Header("Spawn 1 enemy, selectable")]
    [SerializeField] EnemyType enemyType; // valitse halumasi vihollistyyppi
    enum EnemyType { Enemy1, Enemy2, Enemy3, Enemy4 };

    //tee myˆhemmin editor nappula t‰lle toiminnolle
    //tee ensin eventti jolla voit kutsua t‰t‰ toimintaa
    public bool spawnEnemy = false; //bool ollessa true spawnaa vihollisen
    

    void Start()
    {
        //enemyPrefab = new GameObject[enemyNumbers];
       
        SpawnOneAi(spawnEnemy);
        SpawnAllAi();      
    }

    private void SpawnOneAi(bool spawnEnemy)
    {
        if(spawnEnemy == true)
        {
            switch (enemyType)
            {
                case EnemyType.Enemy1:
                    Instantiate(enemyPrefabs[0], spawnPoints[0].position, Quaternion.identity); break;

                case EnemyType.Enemy2:
                    Instantiate(enemyPrefabs[1], spawnPoints[1].position, Quaternion.identity); break;

                case EnemyType.Enemy3:
                    Instantiate(enemyPrefabs[2], spawnPoints[2].position, Quaternion.identity); break;

                case EnemyType.Enemy4:
                    Instantiate(enemyPrefabs[3], spawnPoints[3].position, Quaternion.identity); break;
            }
        }
    }


    public void Spawn1Ai() // Testi metodi
    {
        Instantiate(enemyPrefabs[0], spawnPoints[0].position, Quaternion.identity);
    }

   //private void SpawnAllAi()
   //{
   //     foreach (GameObject enemyy in enemies)
   //     {
   //         enemies = new GameObject[enemyPrefab.Length];
   //         Instantiate(enemies, , Quaternion.identity);
   //     }
   //}

    private void SpawnAllAi()
    {    
        //if(enemyPrefab != null)
        //{
        //    enemyPrefab.SetActive(false);
        //}
        // jos enemys taulukko ei ole tyhj‰
        if(enemies != null && enemyPrefabs!=null)
        {
            //p‰‰tet‰‰n listan pituus tyhjin‰ peliobjekteina, enyNumbers lukum‰‰r‰ll‰ valitaan pituus
            enemies = new GameObject[enemyNumbers];
            
            for (int i = 0; i < enemies.Length; i++)
            {
                //taulukkojen elementit ovat prefabeja
                enemies[i] = enemyPrefabs[i];
               
                var clone = Instantiate(enemies[i], spawnPoints[i].position, Quaternion.identity);
               // clone = enemyPrefab;
            }
        }              
        else // virheilmoitus prefabille myˆs
        {
            Debug.Log("Taulukko" + enemies + "on tyhj‰ tai puuttuu" + enemyPrefabs + "viholliset");          
        }
    }

    // testaa      if (!collisionObj.collider || collisionObj.collider.GetType() != typeof(BoxCollider) // !collisionObj.collider comes first, so that there's no null reference error

    private void SetupAI()
   {
        //asetetaan stateController, Shooting, wayPointList
   }

    private void DisableControl()
    {
        //asetetaan stateController, Shooting, wayPointList
    }

    private void EnableControl()
    {
        //liikkumiskoodi / stateController / shooting pois p‰‰lt‰
    }

    private void Reset()
    {
        //asetetaan Ai:t paikoilleen ja laitetaan p‰‰lle SetActive (true)
    }
}
