using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArea : MonoBehaviour
{
    public float fireDamage = 1f;
    public float cooldown = 0.5f;
    public float Timer = 0;

    private void Start()
    {
        Destroy(gameObject, 3f);

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
}
