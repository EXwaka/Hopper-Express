using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject gate;
    // Start is called before the first frame update
    void Start()
    {
        gate.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.EndCount==true&&MonsterSpawn.monsCount<=0)
        {
            //play animation
            gate.SetActive(false);

        }
        else
        {
            gate.SetActive(true);

        }


    }
}
