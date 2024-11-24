using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    //public Text TimeCounter;
    public float TimeLeft;
    public static float timeLeft;
    public static bool EndCount = false;
    // Start is called before the first frame update
    void Start()
    {

        EndCount = false;
        timeLeft = TimeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Timeleft" + timeLeft);
        timeLeft-=Time.deltaTime;
        TimeLeft-=Time.deltaTime;
        //int min= Mathf.FloorToInt(TimeLeft/60);
        //int sec= Mathf.FloorToInt(TimeLeft%60);
        //TimeCounter.text = string.Format("在時間內保護核心! {0:00}:{1:00}", min, sec);
        if (TimeLeft <= 1)
        {
            //TimeCounter.color = Color.red;

            //TimeCounter.text="任務失敗";
            EndCount = true;

        }

    }

    public void ResetTimer()
    {
        EndCount = false;
        timeLeft = TimeLeft;
    }
}
