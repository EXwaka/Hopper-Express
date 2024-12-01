using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public GameObject core;
    public int HPmax_core=100;
    public int HPcurrent_core;
    public HBbar healthBar;
    private bool dead;
    public GameOverControl gameOverControl;

    public GameObject healingSFX;
    public GameObject heatSFX;
    public float SkillDamage = 20;

    private FlashDam flashDam;
    // Start is called before the first frame update
    void Start()
    {
        healingSFX.SetActive(false);
        flashDam = GetComponent<FlashDam>();
        dead = false;
        HPcurrent_core = HPmax_core;
        healthBar.SetMaxHealth(HPmax_core);

        if (Skills.skill_corehealing)
        {
            InvokeRepeating("Healing", 0, 5f);
            healingSFX.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("coreHP: " + HP_core);
        if (HPcurrent_core <= 0&&!dead)
        {
            StartCoroutine(DeadAnim());
            dead = true;
        
        }
    }

    public void GetHit(int damage)
    {
        BattleDia2.FirstCoreHit = true;
        FindObjectOfType<AudioManager>().Play("coreHit");

        HPcurrent_core -= damage;
        healthBar.SetHealth(HPcurrent_core);
        flashDam.Flash();

        //�L���ޯ�
        if (Skills.skill_coreheat && Random.Range(0f, 1f) <= 0.2f)//20%���vĲ�o�ޯ�
        {
            SkillHeat();
        }

    }

    IEnumerator DeadAnim()
    {
        Time.timeScale = 0.2f;
        //play dead anim
        yield return new WaitForSecondsRealtime(1f);
        gameOverControl.SlideIn();
        Time.timeScale = 0;

    }

    void Healing()
    {
        if (HPcurrent_core < HPmax_core) 
        {
            FindObjectOfType<AudioManager>().Play("coreHealing");
            HPcurrent_core += 10;
            healthBar.SetHealth(HPcurrent_core);
            Quaternion rotation = Quaternion.Euler(-90f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            Instantiate(healingSFX, transform.position, rotation);


        }

    }

    void SkillHeat()
    {
        FindObjectOfType<AudioManager>().Play("coreHeat");
        Instantiate(heatSFX,transform.position,transform.rotation);
        MonsterManager[] monsters = FindObjectsOfType<MonsterManager>();

        // ��C�ӧ�쪺�Ǫ��ե� TakeDamage ��k
        foreach (MonsterManager monster in monsters)
        {
            monster.HitByCore();
        }
    }


}
