using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillmanage : MonoBehaviour
{
    public void ChooseSkill1()
    {
        Skills.skill_throwfire = true;
        Skills.skill_throwice = false;
        Skills.skill_throwpoison = false;

    }
    public void ChooseSkill2()
    {
        Skills.skill_throwfire = false;
        Skills.skill_throwice = true;
        Skills.skill_throwpoison = false;

    }
    public void ChooseSkill3()
    {
        Skills.skill_throwfire = false;
        Skills.skill_throwice = false;
        Skills.skill_throwpoison = true;

    }
    public void ChooseSkill4()
    {
        Skills.skill_forcefield = true;
        Skills.skill_electricfance = false;
        Skills.skill_floorspike = false;

    }
    public void ChooseSkill5()
    {

        Skills.skill_forcefield = false;
        Skills.skill_electricfance = true;
        Skills.skill_floorspike = false;

    }
    public void ChooseSkill6()
    {
        Skills.skill_forcefield = false;
        Skills.skill_electricfance = false;
        Skills.skill_floorspike = true;

    }
    public void ChooseSkill7()
    {
        Skills.skill_player2 = true;
        Skills.skill_jetpack = false;
        Skills.skill_turrets = false;
    }
    public void ChooseSkill8()
    {
        Skills.skill_player2 = false;
        Skills.skill_jetpack = true;
        Skills.skill_turrets = false;
    }
    public void ChooseSkill9()
    {
        Skills.skill_player2 = false;
        Skills.skill_jetpack = false;
        Skills.skill_turrets = true;
    }
    public void ChooseSkill10()
    {
        Skills.skill_airattack = true;
        Skills.skill_automissile = false;
        Skills.skill_berserk = false;

    }
    public void ChooseSkill11()
    {
        Skills.skill_airattack = false;
        Skills.skill_automissile = true;
        Skills.skill_berserk = false;

    }
    public void ChooseSkill12()
    {
        Skills.skill_airattack = false;
        Skills.skill_automissile = false;
        Skills.skill_berserk = true;

    }
    public void ChooseSkill13()
    {
        Skills.skill_obstacle = true;
        Skills.skill_corehealing = false;
        Skills.skill_coreheat = false;

    }
    public void ChooseSkill14()
    {
        Skills.skill_obstacle = false;
        Skills.skill_corehealing = true;
        Skills.skill_coreheat = false;

    }
    public void ChooseSkill15()
    {
        Skills.skill_obstacle = false;
        Skills.skill_corehealing = false;
        Skills.skill_coreheat = true;

    }
}
