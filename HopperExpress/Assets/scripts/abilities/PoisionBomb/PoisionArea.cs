using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisionArea : MonoBehaviour
{
    public float Damage = 1f;
    public float cooldown = 1f;
    public float destroyAfterSec = 5;
    private float Timer = 0;
    public float PoisionDuration = 3f;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Destroy(gameObject, destroyAfterSec);
        FindObjectOfType<AudioManager>().Play("iceFog");


    }

    private void OnTriggerStay(Collider other)
    {
        MonsterManager enemy = other.GetComponent<MonsterManager>();
        if (enemy != null)
        {
            Timer += Time.deltaTime;
            if (Timer >= cooldown)
            {
                enemy.TakeDamage(Damage);
                Timer = 0;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<MonsterManager>(out MonsterManager enemyComponent))
        {
            enemyComponent.Poisioned(PoisionDuration);

        }
    }
}
