using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    public float BulletDamage = 1f;
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
        if (clear >=3) 
        {
            Destroy(this.gameObject);
            clear = 0;
        
        }



    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<MonsterManager>(out MonsterManager enemyComponent))
        {
            //play "explode" animation
            enemyComponent.TakeDamage(BulletDamage);
            Destroy(gameObject);
        }
        if (collision.gameObject)
        {
            //play "explode" animation

            Destroy(gameObject);

        }
    }


}
