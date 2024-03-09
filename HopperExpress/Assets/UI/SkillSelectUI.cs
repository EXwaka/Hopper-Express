using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelectUI : MonoBehaviour
{
    public GameObject SkillMenu;
    // Start is called before the first frame update
    void Start()
    {
        SkillMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(CharacterMove.LevelComplete==true)
        {
            //play animation
            SkillMenu.SetActive(true);
        }
    }
}
