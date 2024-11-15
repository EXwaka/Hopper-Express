using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electric : MonoBehaviour
{
    public GameObject electric;
    public float cooldown = 2;
    public float duration = 1;

    private float startTime;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        electric.SetActive(false);
        startTime = Time.time;
        Invoke("StartAnimation", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.time - startTime; 

        if (elapsedTime >= cooldown)
        {
            electric.SetActive(true);

            if (elapsedTime >= cooldown + duration)
            {
                startTime = Time.time;
            }
        }
        else
        {
            electric.SetActive(false);
        }
    }
    void StartAnimation()
    {
        animator.SetBool("Attack", true);

    }
}
