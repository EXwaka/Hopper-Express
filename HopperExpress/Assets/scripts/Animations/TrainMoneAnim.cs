using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMoneAnim : MonoBehaviour
{
    private Animator animator;
    static public bool TrainGo = false;
    
    void Start()
    {
        // ���Animator����
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ����UE��ɡA���� TrainGo �����A
        if (TrainGo)
        {
            animator.SetBool("TrainGo", TrainGo); // ��sAnimator���������ܶq
        }
    }
}
