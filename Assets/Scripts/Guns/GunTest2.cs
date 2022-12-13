using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTest2 : MonoBehaviour
{
    public enum TriggerType3 { auto = 0, single = 1, burst = 2 };
    //public TriggerType3 triggerType3 = TriggerType3.auto;
    //List<TriggerType3> fireModes = new List<TriggerType3>();
    [SerializeField] TriggerType3 currentMode = TriggerType3.auto;


    //muuta tätä vielä että tätä kutsutaan vain käyttäessä
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            
            switch (currentMode)
            {
                case TriggerType3.auto:
                    currentMode = TriggerType3.single;
                    break;

                case TriggerType3.single:
                    currentMode = TriggerType3.burst;
                    break;

                case TriggerType3.burst:
                    currentMode = TriggerType3.auto;                
                    break;
            }
        }
    }
}
