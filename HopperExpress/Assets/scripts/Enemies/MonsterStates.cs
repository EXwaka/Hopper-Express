using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStates : MonoBehaviour
{
    public GameObject monster;
    public float m_HP = 5f;
    public float cooldown = 1f;
    public float Timer;
    public bool Damaging = false;

    void Start()
    {
        Timer = cooldown;
        Damaging = false;

        if (gameObject.CompareTag("Slime"))
        {
            m_HP = 5f;
        }
        else if (gameObject.CompareTag("Monster1"))
        {
            m_HP = 10f;
        }
    }

    void Update()
    {
        Debug.Log("Slime HP: " + m_HP);

        if (Damaging) 
        {
            Timer += Time.deltaTime;

            if (Timer >= cooldown)
            {
                m_HP -= 1;
                Timer = 0;

                if (m_HP <= 0)
                {
                    Destroy(monster);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "forcefield")
        {
            StartCoroutine(DamageOverTime(other.gameObject));
            Damaging = true;
        }
        if (other.gameObject.tag == "spikefloor")
        {
            m_HP--;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "forcefield")
        {
            Damaging = false;
        }
    }

    IEnumerator DamageOverTime(GameObject enemy)
    {
        Damaging = true;
        while (Damaging)
        {
            yield return new WaitForSeconds(cooldown);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            m_HP--;
            if (m_HP <= 0)
            {
                Destroy(monster);
            }
        }
    }
}
