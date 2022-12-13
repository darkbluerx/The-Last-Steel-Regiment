using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class TimeManager : MonoBehaviour
{
    [Header("The slowing down of time")]
    [SerializeField] float slowdownFactor = 0.05f;

    [Header("The length of the slowed down time in seconds"), Tooltip("Seconds")]
    [SerializeField] float slowdownLenght = 2f;

    //[Header("TestButton P"), Tooltip("Voit vaihtaa näppäintä")]
    //public KeyCode PlayButton = KeyCode.P;

    void Update()
    {
        //if (Input.GetKeyDown(PlayButton))DoSlowmotion();

        Time.timeScale += (1f / slowdownLenght) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void DoSlowmotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
