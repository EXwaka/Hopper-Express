using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onsTacleControl3 : MonoBehaviour
{
    public Animator animator;
    private float CD;
    public float CDmax = 20;
    public GameObject sign;
    public GameObject snowEF;

    static public bool Storming=false;

    void Start()
    {
        CD = CDmax;
        sign.SetActive(false);
        Storming = false;
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        CD -= Time.deltaTime;
        if (CD <= 0)
        {
            Invoke("TriggerScrollGO", 3);
            StartCoroutine(ToggleSign());

            Invoke("StormStart", 4);
            CD = CDmax;
            Invoke("StormStop", 10);

        }
    }

    void TriggerScrollGO()
    {

        animator.SetTrigger("Storm");
        Vector3 spawnPosition = new Vector3(146f, 15.8f, 57f); 
        Quaternion spawnRotation = Quaternion.Euler(0f, 90f, 90f);
        Instantiate(snowEF, spawnPosition, spawnRotation);

    }
    void StormStart()
    {
        Storming=true;
    }
    void StormStop()
    {
        Storming = false;

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
