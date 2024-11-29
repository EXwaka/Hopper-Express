using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBirdControl : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Wavespawner.monsCount += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AnimationAttack()
    {
        animator.SetBool("Walk", false);
        animator.Play("Move");
    }
    void AnimationWalk()
    {
        animator.SetBool("Walk", true);
    }
}
