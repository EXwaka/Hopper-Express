using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsList : MonoBehaviour
{
    [SerializeField] List<Abilities> skills;

    CharacterMove character;

    private void Awake()
    {
        character = GetComponent<CharacterMove>();

        if (skills == null)
        {
            skills = new List<Abilities>();
        }

    }

    public void Equip(Abilities skillsToEquip)
    {
        if (skills == null)
        {
            skills = new List<Abilities>();
        }
        skills.Add(skillsToEquip);
    }

    public void UnEquip(Abilities skillsUnEquip)
    {

    }
}
