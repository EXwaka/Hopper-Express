using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AirAttack : MonoBehaviour
{
    public float damage=20;
    public float Timer= 0.5f;

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Timer-=Time.deltaTime;
        if (Timer < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<MonsterManager>(out MonsterManager enemyComponent))
        {
            enemyComponent.TakeDamage(damage);
        }
    }
}
