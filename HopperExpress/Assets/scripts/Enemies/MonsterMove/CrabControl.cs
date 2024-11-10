using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabControl : MonoBehaviour
{
    // Start is called before the first frame update
    MonsterManager monsterManager;
    private bool isSpeedReduced = false; 


    void Start()
    {
        monsterManager = GetComponent<MonsterManager>();
        
    }


    void Update()
    {
        if (monsterManager.m_HP < 0.3f * monsterManager.maxHP && !isSpeedReduced)
        {
            monsterManager.moveSpeedMax *= 0.5f;
            monsterManager.moveSpeed *= 0.5f;
            isSpeedReduced = true; 
        }
    }

}
