using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandGunBullet : MonoBehaviour
{
    float handGunBulletDamage = 7f;
    float clear;
    float damageReductionTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        clear = 0;
    }

    // Update is called once per frame
    void Update()
    {
        clear += Time.deltaTime;
        damageReductionTimer += Time.deltaTime;

        if (clear >= 0.25f)
        {
            Destroy(this.gameObject);
            clear = 0;
            //destroy bullet after secs
        }
        // reduce 2 damage per 0.1 sec
        if (damageReductionTimer >= 0.1f)
        {
            handGunBulletDamage -= 4f;
            damageReductionTimer = 0f; 

            if (handGunBulletDamage <= 1f)
            {
                handGunBulletDamage = 1f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<MonsterManager>(out MonsterManager enemyComponent))
        {
            //play "explode" animation
            enemyComponent.TakeDamage(handGunBulletDamage);
            Destroy(gameObject);
        }
        else if (other.gameObject)
        {
            //play "explode" animation

            Destroy(gameObject);

        }
    }


}
