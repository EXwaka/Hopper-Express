using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public float m_HP = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            Debug.Log("Slime HP: " + m_HP);

    }
    public void TakeDamage(float damageAmount)//monster take damage
    {
        m_HP -= damageAmount;
        if (m_HP <= 0)
        {
            MonsterSpawn.monsCount--;
            Destroy(gameObject);
            //play animation
        }
    }
}
