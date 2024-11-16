using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionArae : MonoBehaviour
{
    public float Damage=30f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("selfDestruction", 0.5f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<MonsterManager>(out MonsterManager enemyComponent))
        {
            enemyComponent.TakeDamage(Damage);

        }
    }
    void selfDestruction()
    {
        Destroy(gameObject);
    }
}
