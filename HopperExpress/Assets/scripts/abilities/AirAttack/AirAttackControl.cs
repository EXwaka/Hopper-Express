using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirAttackControl : MonoBehaviour
{
    public GameObject AttackArea;
    Animator animator;
    static public float CD = 20f;  
    static public bool isOnCooldown = false;  

    void Start()
    {
        CD = 20;
        isOnCooldown=false;
        AttackArea.SetActive(false);
        if (Skills.skill_airattack)
        {
            gameObject.SetActive(true);

        }
        else
        {
            gameObject.SetActive(false);

        }
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && !isOnCooldown)
        {
            FindObjectOfType<AudioManager>().Play("Plane");
            FindObjectOfType<AudioManager>().Play("Bombard");

            AttackArea.SetActive(true);
            animator.SetTrigger("Attack");

            StartCoroutine(HandleCooldown());
        }
    }

    IEnumerator HandleCooldown()
    {
        isOnCooldown = true;  

        yield return new WaitForSeconds(CD);
        AttackArea.SetActive(false);
        isOnCooldown = false;  
    }
}
