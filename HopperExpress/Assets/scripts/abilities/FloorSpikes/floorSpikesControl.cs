using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class floorSpikesControl : MonoBehaviour
{
    public GameObject floorSpikes;
    public float floorSpikeDamage = 1f;
    public float cooldown = 0.5f;
    public float setCooldown = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        if(Skills.skill_floorspike==true)
        {
            floorSpikes.SetActive(true);
        }
        else
        {
            floorSpikes.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<MonsterManager>(out MonsterManager enemyComponent))
        {
            Debug.Log("Monster enter");
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                enemyComponent.TakeDamage(floorSpikeDamage);
                cooldown = setCooldown;
            }
        }
    }

}
