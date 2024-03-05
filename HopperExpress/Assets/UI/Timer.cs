using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public Text TimeCounter;
    public float TimeLeft =5f;
    public bool EndCount = false;
    // Start is called before the first frame update
    void Start()
    {
        EndCount = false;
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft-=Time.deltaTime;
        int min= Mathf.FloorToInt(TimeLeft/60);
        int sec= Mathf.FloorToInt(TimeLeft%60);
        TimeCounter.text = string.Format("{0:00}:{1:00}", min, sec);
        if (TimeLeft <= 1)
        {
            TimeCounter.color = Color.green;

            TimeCounter.text="任務完成";

        }

    }
}
