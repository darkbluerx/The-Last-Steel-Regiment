using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTest : MonoBehaviour
{
    public class Numbers
    {
        public string string1;
        public int num2;

        public Numbers(string newString1, int newNumber2)
        {
            string1 = newString1;
            num2 = newNumber2;
        }
    }

    public enum TriggerType {auto,single,burst };
    public TriggerType triggerType = TriggerType.auto;
    
    private void Start()
    {
        List<Numbers> intList = new List<Numbers>();

        intList.Add(new Numbers("sas", 2));

        List<TriggerType> modi = new List<TriggerType>();
        modi.Add(TriggerType.auto);
        modi.Add(TriggerType.single);
        modi.Add(TriggerType.burst);

        foreach (var TriggerType in modi)
        {
            //print([])
        }

    }

    public enum TriggerType2 { auto, single, burst };
    public TriggerType2 triggerType2 = TriggerType2.auto;

    List<TriggerType2> fireModes = new List<TriggerType2>();

    int m_curretMode;

    private void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if (Input.GetKeyDown(KeyCode.T + i))
            {
                int mode = 0;
                if (i == 0) mode = 3;
                else mode = i - 1;
                if(mode < fireModes.Count)
                {
                    Debug.Log(fireModes.Count);
                    //ChangeMode(mode);
                }
            }
        }
    }

    void ChangeMode(int number)
    {

    }

}
