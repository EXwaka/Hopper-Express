using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IceArea : MonoBehaviour
{
    public float destroyAfterSec = 0.2f;
    private float frozenTime = 1.5f;
    private float Damage = 5;
    //public Animator animator;

    void Start()
    {
        //animator = GetComponent<Animator>();
        //animator.SetBool("IsBurning", true);
        Destroy(gameObject, destroyAfterSec);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<MonsterManager>(out MonsterManager enemyComponent))
        {
            enemyComponent.Frozen(frozenTime);
            enemyComponent.TakeDamage(Damage);
        }
    }
}
