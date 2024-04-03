using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class electricFance : MonoBehaviour
{
    public Animator animator;
    public float electricDamage = 1;
    public float cooldown = 0.5f;
    public float Timer = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        attack();
    }
    void attack()
    {
        animator.SetBool("IsAttacking", true);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<MonsterManager>(out MonsterManager enemyComponent))
        {
            Timer += Time.deltaTime;
            if (Timer >= cooldown)
            {
                enemyComponent.TakeDamage(electricDamage);
                Timer = 0;
            }
        }

    }
}
