using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public float m_HP = 5f;
    public Transform MonsAttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask enemy;
    public bool MonsInRange;
    public float MonsDamage = 1;
    public float atkCooldown = 1;
    public float Counter = 0;
    private bool isAttacking = false;

    private Wavespawner waveSpawner;

    // Start is called before the first frame update
    void Start()
    {
        MonsInRange = false;

        waveSpawner = GetComponentInParent<Wavespawner>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Slime HP: " + m_HP);
        //Debug.Log("monster in range:" + MonsInRange);

        if (MonsInRange == true)
        {
            Counter += Time.deltaTime;
            if (Counter >= atkCooldown)
            {
                //play "MonsterAttack" animation
                MonsterAttack(MonsDamage);
                Counter = 0;
            }

        }

    }
    public void TakeDamage(float damageAmount)//monster take damage
    {
        //play "hurt" animation
        m_HP -= damageAmount;
        if (m_HP <= 0)
        {
            //play "dead" animation
            MonsterSpawn.monsCount--;
            Destroy(gameObject);
            //waveSpawner.waves[waveSpawner.currentWaveIndex].enemiesLeft--;
        }

    }

    public void MonsterAttack(float damageAmount)
    {
        if (!isAttacking) 
        {
            isAttacking = true; 

            Collider[] HitAny = Physics.OverlapSphere(MonsAttackPoint.position, AttackRange, enemy);

            foreach (Collider enemy in HitAny)
            {
                //Debug.Log("Target gets hit:" + enemy.name);
                Core.HP_core -= damageAmount;

            }

            isAttacking = false; 
        }
    }
    void OnDrawGizmosSelected()
    {
        if(MonsAttackPoint == null)
            return;
        
        Gizmos.DrawSphere(MonsAttackPoint.position, AttackRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ( "MonsterAttackRange"))
        {
            MonsInRange= true;
        } 
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag( "MonsterAttackRange"))
        {
            MonsInRange = false;
        }
    }

}
