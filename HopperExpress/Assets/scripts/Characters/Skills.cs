using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public static bool skill_throwfire = false;//1
    public static bool skill_throwice = false;//2
    public static bool skill_throwpoison = false;//3

    public static bool skill_turrets = false;//4
    public static bool skill_electricfance = false;//5
    public static bool skill_floorspike=false;//6

    public static bool skill_forcefield=false;//7
    public static bool skill_corehealing=false;//8
    public static bool skill_coreheat=false;//9

    public static bool skill_airattack = false;//10


    // Start is called before the first frame update
    void Start()
    {


    }
    private void Awake()
    {
    }

    //public bool CanUseGreekFire()
    //{
    //    return skillManager.IsSkillUnlocked(SkillsManager.SkillType.GreekFire);
    //}
}
