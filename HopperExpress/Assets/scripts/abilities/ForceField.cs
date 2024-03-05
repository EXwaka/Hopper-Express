using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    public GameObject forcefield;

    public float ForceDamage = 1f;
    public float cooldown = 0.5f;
    public float Timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (Skills.skill_forcefield == true)
        {
            forcefield.SetActive(true);
        }
        else
        {
            forcefield.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<MonsterManager>(out MonsterManager enemyComponent))
        {
            Timer += Time.deltaTime;
            if (Timer >= cooldown)
            {
                enemyComponent.TakeDamage(ForceDamage);
                Timer = 0;
            }
        }

    }

}
