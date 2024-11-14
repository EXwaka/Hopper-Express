using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text GreekFireText;
    public GameObject GreekFireImg; 

    public Text ThrowIceText;
    public GameObject ThrowIceImg;

    public Text ThrowPoisionText;
    public GameObject ThrowPoisionImg;

    private float GreekFireCD;
    private float ThrowIceCD;
    private float ThrowPoisionCD;

    void Start()
    {
        GreekFireImg.SetActive(false);
        ThrowIceImg.SetActive(false);
        ThrowPoisionImg.SetActive(false);


        CheckGreekFire();
        CheckThrowIce();
        CheckThrowPoision();
    }

    // Update is called once per frame
    void Update()
    {
        GreekFire();
        Throwice();
        ThrowPoision();
    }

    void CheckGreekFire()
    {
        if (Skills.skill_throwfire)
        {
            GreekFireImg.SetActive(true);
            GreekFireText.text = "";
            GreekFireCD = ThrowFire.greekFireCD;
        }

    }
    void CheckThrowIce()
    {
        if (Skills.skill_throwice)
        {
            ThrowIceImg.SetActive(true);
            ThrowIceText.text = "";
            ThrowIceCD = ThrowIce.iceBombCD;
        }
    }

    void CheckThrowPoision()
    {
        if (Skills.skill_throwpoison)
        {
            ThrowPoisionImg.SetActive(true);
            ThrowPoisionText.text = "";
            ThrowIceCD = ThrowIce.iceBombCD;
        }
    }


    void GreekFire()
    {
        if(ThrowFire.CDactivated)
        {
            GreekFireCD -= Time.deltaTime;
            GreekFireText.text = GreekFireCD.ToString("F0");
        }
        else if(!ThrowFire.CDactivated)
        {
            GreekFireText.text = "";
            GreekFireCD = ThrowFire.greekFireCD;
        }
    }
    void Throwice()
    {
        if (ThrowIce.CDactivated)
        {
            ThrowIceCD -= Time.deltaTime;
            ThrowIceText.text = ThrowIceCD.ToString("F0");

        }
        else if (!ThrowIce.CDactivated)
        {
            ThrowIceText.text = "";
            ThrowIceCD = ThrowIce.iceBombCD;
        }
    }

    void ThrowPoision()
    {
        if (PoisionBomb.CDactivated)
        {
            ThrowPoisionCD -= Time.deltaTime;
            ThrowPoisionText.text = ThrowPoisionCD.ToString("F0");
        }
        else if (!PoisionBomb.CDactivated)
        {
            ThrowPoisionText.text = "";
            ThrowPoisionCD = PoisionBomb.poisionBombCD;
        }
    }
}
