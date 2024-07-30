using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public static bool skill_floorspike=false;
    public static bool skill_forcefield=false;
    public static bool skill_throwfire=false;
    public static bool skill_throwice=false;
    public static bool skill_electricfance=false;
    public static bool skill_airattack=false;

    private SkillsManager skillManager;

    // Start is called before the first frame update
    void Start()
    {


    }
    private void Awake()
    {
        skillManager = new SkillsManager();
    }

    public bool CanUseGreekFire()
    {
        return skillManager.IsSkillUnlocked(SkillsManager.SkillType.GreekFire);
    }
}
