using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheater : MonoBehaviour
{
    public Core core;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Timer.timeLeft = 0;
            Wavespawner.monsCount=0;
        }
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            core.HPcurrent_core -= 20;
        }
    }
}
