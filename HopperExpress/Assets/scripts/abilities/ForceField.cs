using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    public GameObject forcefield;

    private float ForceDamage = 8f;
    public float cooldown = 0.3f;
    public float Timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        //copy the code in void update to here once the game complete
    }

    // Update is called once per frame
    void Update()
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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<MonsterManager>(out MonsterManager enemyComponent))
        {
            Timer += Time.deltaTime;
            if (Timer >= cooldown)
            {
                Debug.Log("attacking");
                enemyComponent.TakeDamage(ForceDamage);
                Timer = 0;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<MonsterManager>(out MonsterManager enemyComponent))
        {
            Timer = 0;
        }
    }
}
