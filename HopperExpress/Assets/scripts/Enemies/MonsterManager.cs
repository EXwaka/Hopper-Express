using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    private FlashDam flashDam;
    //private FlashFrozen flashfrozen;
    public bool Freeze=false;
    public bool Poision=false;
    public GameObject target;
    public float moveSpeed=1;
    public float moveSpeedMax;

    public float maxHP;
    public float m_HP = 5f;
    public float currentHP;
    public MonsterHP healthBar;

    public Transform MonsAttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask enemy;
    public bool MonsInRange;
    public int MonsDamage = 1;
    public float atkCooldown = 1;
    public float Counter = 0;
    bool isDead=false;
    private Animator animator;
    public GameObject explosion;

    private Rigidbody rb;
    private float knockbackForce = 800f;

    private Wavespawner waveSpawner;
    CrabControl crabControl;
    EagleControl eagleControl;

    [SerializeField] private Material poisionMaterial;
    [SerializeField] private Material frozenMaterial;
    private SpriteRenderer spriteRenderer;

    private Material originalMaterial;

    // Start is called before the first frame update
    void Start()
    {
        flashDam = GetComponent<FlashDam>();
        //flashfrozen = GetComponent<FlashFrozen>();

        currentHP = maxHP;
        healthBar.SetMaxHealth(maxHP);

        MonsInRange = false;
        moveSpeedMax = moveSpeed;
        waveSpawner = GetComponentInParent<Wavespawner>();
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

        crabControl = GetComponent<CrabControl>();
        eagleControl = GetComponentInParent<EagleControl>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("HP: " + m_HP);
        //Debug.Log("monster in range:" + MonsInRange);
        MoveToTarget();
        if (MonsInRange)
        {
            Counter += Time.deltaTime;

            // 檢查冷卻計時器是否已達冷卻時間
            if (Counter >= atkCooldown)
            {
                MonsterAttack(MonsDamage);
                Counter = 0; // 重置計時器
            }
        }

    }
    public void MoveToTarget()
    {
        if (target != null)
        {

            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = new Vector3(target.transform.position.x, 0f, 0f);
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);//一般怪物移動


            if (eagleControl != null)//老鷹移動方法
            {

                if (eagleControl.AttackRange)
                {
                    transform.position = Vector3.MoveTowards(currentPosition, targetPosition, moveSpeed *2* Time.deltaTime);//一般怪物移動
                }
                else
                {
                    Vector3 EagletargetPosition = new Vector3(target.transform.position.x, currentPosition.y, 0f);
                    transform.position = Vector3.MoveTowards(currentPosition, EagletargetPosition, moveSpeed * Time.deltaTime);
                }
            }


            if(targetPosition.x>currentPosition.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);

            }
        }
    }
    public void TakeDamage(float damageAmount)
    {
        if (isDead) return;  // 如果怪物已經死亡，則不執行後續邏輯
        flashDam.Flash();

        //寄居蟹判斷
        if (crabControl != null && currentHP <= 0.3f * maxHP)
        {
            damageAmount *= 0.7f; 
        }

        if (Poision)
        {
            damageAmount *= 2;
        }
        currentHP -= (float)damageAmount;
        healthBar.SetHealth(currentHP);



        m_HP -= damageAmount;

        if (m_HP <= 0)
        {

            isDead = true;
            FindObjectOfType<AudioManager>().Play("MonsterDeath");
            Death();
        }

    }
    public void Death()
    {
        DeadAnimation();
        Destroy(gameObject);
        Wavespawner.monsCount--;
        MonsterSpawn.monsCount--;

        BerserkControl berserk=FindObjectOfType<BerserkControl>();
        berserk.berserkDuration += 0.5f;

    }
    private void DeadAnimation()
    {
        GameObject explosionInstance = Instantiate(explosion, transform.position, transform.rotation);

        Destroy(explosionInstance, 0.5f);
    }

    public void MonsterAttack(int damageAmount)
    {
        if(!Freeze)
        {
            Collider[] HitAny = Physics.OverlapSphere(MonsAttackPoint.position, AttackRange, enemy);

            foreach (Collider enemy in HitAny)
            {
                Core core = enemy.GetComponent<Core>();
                if (core != null)
                {
                    core.GetHit(damageAmount);
                }
            }
        }

    }

    public void Shock(float shockTime)
    {
        FindObjectOfType<AudioManager>().Play("Electric");

        moveSpeed = 0;
        StartCoroutine(RecoverSpeed(shockTime));
    }
    public void Frozen(float frozenTime)
    {
        Freeze=true;
        spriteRenderer.material = frozenMaterial;

        moveSpeed = 0;
        StartCoroutine(RecoverSpeed(frozenTime));

    }
    public void ColdSlow(float slowDownTime)
    {
        Freeze = true;
        spriteRenderer.material = frozenMaterial;


        moveSpeed *= 0.3f;
        StartCoroutine(RecoverSpeed(slowDownTime));
    }
    public void Poisioned(float PoisionDuration)
    {
        Poision = true;
        spriteRenderer.material = poisionMaterial;

        StartCoroutine(RecoverSpeed(PoisionDuration));
    }
    public void Burning(float slowDownTime)
    {
        moveSpeed *= 0.8f; 
        InvokeRepeating("BurningDamage", 0f, 0.5f);
        StartCoroutine(RecoverSpeed(slowDownTime));
    }
    private void BurningDamage()
    {
        TakeDamage(2f);
    }

    public void HitByCore()
    {
        Invoke("CoreAttack", 0.5f);

    }
    private void CoreAttack()
    {
        rb.AddForce(Vector3.up * knockbackForce);
        TakeDamage(15);
    }
    private IEnumerator RecoverSpeed(float Time)
    {
        yield return new WaitForSeconds(Time);
        Freeze = false;
        Poision = false;
        spriteRenderer.material = originalMaterial;
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
