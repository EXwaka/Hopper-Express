using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretActive : MonoBehaviour
{
    public GameObject Turret;
    // Start is called before the first frame update
    void Start()
    {
        if (Skills.skill_turrets)
        {
            Turret.SetActive(true);
        }
        else
        {
            Turret.SetActive(false);
        }

    }

}
