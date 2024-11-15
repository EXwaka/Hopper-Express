using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class electricFance : MonoBehaviour
{
    public float electricDamage = 5;
    public float cooldown = 0.5f;
    public float Timer = 1;
    public float shockTime = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<MonsterManager>(out MonsterManager enemyComponent))
        {
            Timer += Time.deltaTime;
            if (Timer >= cooldown)
            {
                enemyComponent.TakeDamage(electricDamage);
                enemyComponent.Shock(shockTime);
                Timer = 0;
            }
        }

    }
}
