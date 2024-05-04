using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArea : MonoBehaviour
{
    public float fireDamage = 2f;
    public float cooldown = 0.5f;
    public float destroyAfterSec=5;
    public float Timer = 0;
    public float slowDownTime = 0.8f;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsBurning", true);
        Destroy(gameObject, destroyAfterSec);

    }

    private void OnTriggerStay(Collider other)
    {
        MonsterManager enemy = other.GetComponent<MonsterManager>();
        if (enemy != null)
        {
            Timer += Time.deltaTime;
            if (Timer >= cooldown)
            {
                enemy.TakeDamage(fireDamage);
                Timer = 0;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<MonsterManager>(out MonsterManager enemyComponent))
        {
            enemyComponent.Burning(slowDownTime);

        }
    }
}
