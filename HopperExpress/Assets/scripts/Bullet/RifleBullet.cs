using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class RifleBullet : MonoBehaviour
{
    public float rifleBulletDamage = 3f;
    float clear = 3;
    // Start is called before the first frame update
    void Start()
    {
        clear = 0;
    }

    // Update is called once per frame
    void Update()
    {
        clear += Time.deltaTime;
        if (clear >= 3)
        {
            Destroy(this.gameObject);
            clear = 0;
            //destroy bullet after secs
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<MonsterManager>(out MonsterManager enemyComponent))
        {
            //play "explode" animation
            enemyComponent.TakeDamage(rifleBulletDamage);
            Destroy(gameObject);
        }
        else if (other.gameObject)
        {
            //play "explode" animation

            Destroy(gameObject);

        }
    }


}
