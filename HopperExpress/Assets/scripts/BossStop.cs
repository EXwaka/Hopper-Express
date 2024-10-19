using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<grasshopperBoss>(out grasshopperBoss boss))
        {
            if(other.gameObject.TryGetComponent<MonsterManager>(out MonsterManager enemy))
            {
                enemy.moveSpeed = 0;
            }
            //Debug.Log("BossHit");

            boss.moveSpeed=0;

        }
    }
}
