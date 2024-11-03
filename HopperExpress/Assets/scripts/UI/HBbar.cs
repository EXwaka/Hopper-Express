using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HBbar : MonoBehaviour
{
    public static HBbar instance;
    public Slider slider;

    private void Awake()
    {
        Transform rootObject = transform.root;  // 找到當前物件的根物件
        //DontDestroyOnLoad(rootObject.gameObject);
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
