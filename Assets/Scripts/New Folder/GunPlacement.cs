using System.Collections.Generic;
using UnityEngine;

public class GunPlacement : MonoBehaviour
{
    [Header("Instantiate all guns")]
    [SerializeField] GameObject[] gunList;
    //[SerializeField, Range(1,20)] int gunNumber;
    [SerializeField] Transform[] gunPosition;
    [Space]
    [Space]

    //[Header("Location next to the Player")]
    Vector3 gunDistance = new Vector3(0, 0, 0);
    
    [Header("Select your gun & instantiate one gun")]
    [SerializeField] GameObject[] fixedGunList;
    [SerializeField] Transform[] fixedGunPosition;
    public enum SelectedGun { hangun, submachine, rifle, machinegun };
    
    [System.Serializable]
    public class GunTypePair
    {
        public SelectedGun key;
        public GameObject value;       
    }

    public SelectedGun selectedGun;
    public List<GunTypePair> selectedGunList = new List<GunTypePair>();
    Dictionary<SelectedGun, GameObject> selectedGunDict = new Dictionary<SelectedGun, GameObject>();

    private void Awake()
    {
        foreach (var keyvalue in selectedGunList)
        {
            selectedGunDict[keyvalue.key] = keyvalue.value;
        }
    }

    private void Start()
    {
        //SpawnOneGun();    
        SpawnAllGuns();
    }

    private void SpawnAllGuns()
    {
        if(gunList != null) 
        {
            //gunList = new GameObject[gunNumber];

            for (int i = 0; i < gunList.Length; i++)
            {
                var clone = Instantiate(gunList[i], gunPosition[i].position, Quaternion.identity);
            }
        }
    }

    public void SpawnOneGun()
    {
        for (int i = 0; i < selectedGunList.Count; i++)
        {
            Instantiate(selectedGunDict[selectedGun], gunPosition[i].position + gunDistance, Quaternion.identity);
        }    
    }
}