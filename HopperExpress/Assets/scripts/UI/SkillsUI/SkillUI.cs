using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    //1
    public Text GreekFireText;
    public GameObject GreekFireImg; 
    //2
    public Text ThrowIceText;
    public GameObject ThrowIceImg;
    //3
    public Text ThrowPoisionText;
    public GameObject ThrowPoisionImg;
    //4
    public Text forceFieldText;
    public GameObject forceFieldImg;
    //5
    public Text fanceText;
    public GameObject fanceImg;
    //6
    public Text spikeText;
    public GameObject spikeImg;
    //7
    public Text P2Text;
    public GameObject P2Img;
    //8
    public Text jetText;
    public GameObject jetImg;
    //9
    public Text turretText;
    public GameObject turretImg;
    //10
    public Text airAttackText;
    public GameObject airAttackImg;    
    //11
    public Text missileText;
    public GameObject missileImg;
    //12
    public Text berserkText;
    public GameObject berserkImg;
    //13
    public Text corehealText;
    public GameObject corehealImg;
    //14
    public Text corewaveText;
    public GameObject corewaveImg;

    private float GreekFireCD;
    private float ThrowIceCD;
    private float ThrowPoisionCD;
    private float airAttackCD;
    private float missileCD;
    private float berserkCD;

    void Start()
    {

        CheckGreekFire();
        CheckThrowIce();
        CheckThrowPoision();
        CheckForceField();
        CheckFance();
        Checkspike();
        CheckP2();
        CheckJet();
        CheckTurret();
        CheckAirAttack();
        CheckBerserk();
        CheckMissile();
        CheckCoreHeal();
        CheckCoreWave();
    }

    // Update is called once per frame
    void Update()
    {
        GreekFire();
        Throwice();
        ThrowPoision();
        AirAttack();
        Berserk();
        Missile();  
    }

    void CheckGreekFire()
    {
        if (Skills.skill_throwfire)
        {
            GreekFireImg.SetActive(true);
            GreekFireText.text = "";
            GreekFireCD = ThrowFire.greekFireCD;
        }
        else
        {
            GreekFireImg.SetActive(false);

        }

    }
    void GreekFire()
    {
        if (ThrowFire.CDactivated)
        {
            GreekFireCD -= Time.deltaTime;
            GreekFireText.text = GreekFireCD.ToString("F0");
        }
        else if (!ThrowFire.CDactivated)
        {
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
        else
        {
            ThrowIceImg.SetActive(false);

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

    void CheckThrowPoision()
    {
        if (Skills.skill_throwpoison)
        {
            ThrowPoisionImg.SetActive(true);
            ThrowPoisionText.text = "";
            ThrowIceCD = ThrowIce.iceBombCD;
        }
        else
        {
            ThrowPoisionImg.SetActive(false);
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

    void CheckForceField()
    {
        if (Skills.skill_forcefield)
        {
            forceFieldImg.SetActive(true);
            forceFieldText.text = "啟用中";

            spikeText.fontSize = 25;
            spikeText.color = Color.yellow;
        }
        else
        {
            forceFieldImg.SetActive(false);

        }
    }

    void CheckFance()
    {
        if (Skills.skill_electricfance)
        {
            fanceImg.SetActive(true);
            fanceText.text = "啟用中";

            fanceText.fontSize = 25;
            fanceText.color = Color.yellow;
        }
        else
        {
            fanceImg.SetActive(false);
        }

    }

    void Checkspike()
    {
        if (Skills.skill_floorspike)
        {
            spikeImg.SetActive(true);
            spikeText.text = "啟用中";

            spikeText.fontSize = 25;
            spikeText.color = Color.yellow;
        }
        else
        {
            spikeImg.SetActive(false);
        }

    }

    void CheckP2()
    {
        if (Skills.skill_player2)
        {
            P2Img.SetActive(true);
            P2Text.text = "啟用中";

            P2Text.fontSize = 25;
            P2Text.color = Color.yellow;
        }
        else { P2Img.SetActive(false); }

    }

    void CheckJet()
    {
        if (Skills.skill_jetpack)
        {
            jetImg.SetActive(true);
            jetText.text = "啟用中";

            jetText.fontSize = 25;
            jetText.color = Color.yellow;
        }
        else
        {
            jetImg.SetActive(false) ;
        }

    }

    void CheckTurret()
    {
        if (Skills.skill_turrets)
        {
            turretImg.SetActive(true);
            turretText.text = "啟用中";

            turretText.fontSize = 25;
            turretText.color = Color.yellow;
        }
        else
        {
            turretImg.SetActive(false);
        }

    }

    void CheckAirAttack()
    {
        if (Skills.skill_airattack)
        {
            airAttackImg.SetActive(true);
            airAttackText.text = "";
            airAttackCD = AirAttackControl.CD;
        }
        else
        {
            airAttackImg.SetActive(false);

        }

    }
    void AirAttack()
    {
        if (AirAttackControl.isOnCooldown)
        {
            airAttackCD -= Time.deltaTime;
            airAttackText.text = airAttackCD.ToString("F0");
        }
        else if (!AirAttackControl.isOnCooldown)
        {
            airAttackText.text = "";
            airAttackCD = AirAttackControl.CD;
        }
    }

    void CheckBerserk()
    {
        if (Skills.skill_berserk)
        {
            berserkImg.SetActive(true);
            berserkText.text = "";
            berserkCD = BerserkControl.CD;

        }
        else
        {
            berserkImg.SetActive(false);

        }

    }
    void Berserk()
    {

        if (BerserkControl.UIActivated)
        {
            berserkText.text = "啟用中";

            berserkText.fontSize = 25;
            berserkText.color = Color.yellow;

        }
        else if (BerserkControl.isOnCooldown)
        {
            berserkCD -= Time.deltaTime;
            berserkText.text = berserkCD.ToString("F0");

            berserkText.fontSize = 50;
            berserkText.color = Color.black;

        }
        else if (!BerserkControl.isOnCooldown)
        {
            berserkText.text = "已準備";
            berserkCD = BerserkControl.CD;
            berserkText.fontSize = 25;

            berserkText.color = Color.green;
        }
    }

    void CheckMissile()
    {
        if (Skills.skill_automissile)
        {
            missileImg.SetActive(true);
            missileText.text = "";
            missileCD = AutoMissileControl.CD;
        }
        else
        {
            missileImg.SetActive(false);

        }

    }
    void Missile()
    {
        if (AutoMissileControl.UILaunching)
        {
            missileCD -= Time.deltaTime;
            missileText.text = missileCD.ToString("F0");
        }
        else if (!AutoMissileControl.UILaunching)
        {
            missileText.text = "";
            missileCD = AutoMissileControl.CD;
        }
    }
    void CheckCoreHeal()
    {
        if (Skills.skill_corehealing)
        {
            corehealImg.SetActive(true);
            corehealText.text = "啟用中";

            corehealText.fontSize = 25;
            corehealText.color = Color.yellow;
        }
        else
        {
            corehealImg.SetActive(false);

        }
    }
    void CheckCoreWave()
    {
        if (Skills.skill_coreheat)
        {
            corewaveImg.SetActive(true);
            corewaveText.text = "啟用中";

            corewaveText.fontSize = 25;
            corewaveText.color = Color.yellow;
        }
        else
        {
            corewaveImg.SetActive(false);

        }
    }
}
