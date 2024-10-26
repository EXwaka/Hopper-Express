using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHP : MonoBehaviour
{
    public static MonsterHP instance;
    public Slider slider;
    // Start is called before the first frame update
    private void Awake()
    {
        Transform rootObject = transform.root;
    }
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
