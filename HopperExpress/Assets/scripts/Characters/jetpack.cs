using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jetpack : MonoBehaviour
{
    public GameObject SmokeEF;
    CharacterMove Character;
    // Start is called before the first frame update
    void Start()
    {
        Character = GetComponentInParent<CharacterMove>();
        SmokeEF.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Character.activeJet)
        {
            SmokeEF.SetActive(true);
        }
        else if(!Character.activeJet)
        {
            SmokeEF.SetActive(false);
        }
    }
}
