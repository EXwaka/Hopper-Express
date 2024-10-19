using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMoneAnim : MonoBehaviour
{
    private Animator animator;
    static public bool TrainGo = false;
    
    void Start()
    {
        // 獲取Animator元件
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 當按下E鍵時，切換 TrainGo 的狀態
        if (TrainGo)
        {
            animator.SetBool("TrainGo", TrainGo); // 更新Animator中的布爾變量
        }
    }
}
