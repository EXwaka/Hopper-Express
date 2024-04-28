using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricFanceControl : MonoBehaviour
{
    public GameObject electricFance;
    // Start is called before the first frame update
    void Start()
    {
        if(Skills.skill_electricfance==true)
        {
            electricFance.SetActive(true);
        }
        else
        {
            electricFance.SetActive(false);

        }

    }

}
