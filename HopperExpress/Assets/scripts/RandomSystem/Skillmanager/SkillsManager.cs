using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu]
public class SkillsManager
{
    public enum SkillType
    {
        GreekFire,
    }
    private List<SkillType> unlockSkillTypeList;

    public SkillsManager()
    {
        unlockSkillTypeList = new List<SkillType>();
    }


    public void UnlockSkill(SkillType skillType)
    {
        unlockSkillTypeList.Add(skillType);
    }

    public bool IsSkillUnlocked(SkillType skillType)
    {
        return unlockSkillTypeList.Contains(skillType);
    }
}
