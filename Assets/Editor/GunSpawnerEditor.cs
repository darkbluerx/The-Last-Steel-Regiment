using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GunSpawner))]
public class GunSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
       
        GunSpawner myScript = (GunSpawner)target;
        if(GUILayout.Button("Spawn Gun"))
        {           
            myScript.SpawnGun();
        }
    }


}
