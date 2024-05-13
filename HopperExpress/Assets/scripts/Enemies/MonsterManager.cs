using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed=1;
    public float moveSpeedMax;

    public float m_HP = 5f;
    public Transform MonsAttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask enemy;
    public bool MonsInRange;
    public int MonsDamage = 1;
    public float atkCooldown = 1;
    public float Counter = 0;
    private bool isAttacking = false;

    private Wavespawner waveSpawner;

    // Start is called before the first frame update
    void Start()
    {
        MonsInRange = false;
        moveSpeedMax = moveSpeed;
        waveSpawner = GetComponentInParent<Wavespawner>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Slime HP: " + m_HP);
        //Debug.Log("monster in range:" + MonsInRange);
        MoveToTarget();
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
    public void MoveToTarget()
    {
        if (target != null)
        {
            Vector3 currentPosition = transform.position;

            Vector3 targetPosition = new Vector3(target.transform.position.x, 0f, 0f);

            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
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
            FindObjectOfType<AudioManager>().Play("MonsterDeath");
            Destroy(gameObject);
            Wavespawner.monsCount--;
        }

    }

    public void MonsterAttack(int damageAmount)
    {
        if (!isAttacking) 
        {
            isAttacking = true; 

            Collider[] HitAny = Physics.OverlapSphere(MonsAttackPoint.position, AttackRange, enemy);

            foreach (Collider enemy in HitAny)
            {
                //Debug.Log("Target gets hit:" + enemy.name);
                Core core = enemy.GetComponent<Core>();
                if (core != null)
                {
                    core.GetHit(damageAmount);
                }
            }

            isAttacking = false; 
        }
    }

    public void Shock(float shockTime)
    {
        moveSpeed = 0;
        StartCoroutine(RecoverSpeed(shockTime));
    }
    public void Frozen(float frozenTime)
    {
        moveSpeed = 0;
        StartCoroutine(RecoverSpeed(frozenTime));
    }
    public void ColdSlow(float slowDownTime)
    {
        moveSpeed *= 0.3f;
        StartCoroutine(RecoverSpeed(slowDownTime));
    }
    public void Burning(float slowDownTime)
    {
        moveSpeed *= 0.7f;
        StartCoroutine(RecoverSpeed(slowDownTime));
    }

    private IEnumerator RecoverSpeed(float Time)
    {
        yield return new WaitForSeconds(Time);
        moveSpeed = moveSpeedMax;
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
            moveSpeed = 0;

        }
        if (other.CompareTag("floorspike"))
        {
            moveSpeed *= 0.3f;
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag( "MonsterAttackRange"))
        {
            MonsInRange = false;
            moveSpeed = moveSpeedMax;

        }
        if (other.CompareTag("floorspike"))
        {
            moveSpeed = moveSpeedMax;
        }

    }



}
