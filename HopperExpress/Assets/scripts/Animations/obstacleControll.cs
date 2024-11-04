using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class obstacleControll : MonoBehaviour
{
    public Animator animator;
    private float CD=20;
    private float CDmax = 20;
    public GameObject sign;

    void Start()
    {
        sign.SetActive(false);
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        CD-=Time.deltaTime;
        if (CD<=0)
        {
            Invoke("TriggerScrollGO", 3);
            StartCoroutine(ToggleSign());

            CD = CDmax;
        }
    }

    void TriggerScrollGO()
    {
        animator.SetTrigger("ScrollGo");
    }

    IEnumerator ToggleSign()
    {
        for (int i = 0; i < 6; i++) // ¶}Ãö 6 ¦¸
        {
            sign.SetActive(!sign.activeSelf);
            yield return new WaitForSeconds(0.5f); 
        }

    }

}
