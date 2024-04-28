using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorSpikesControl : MonoBehaviour
{
    public GameObject floorSpikes;
    // Start is called before the first frame update
    void Start()
    {
        if(Skills.skill_floorspike==true)
        {
            floorSpikes.SetActive(true);
        }
        else
        {
            floorSpikes.SetActive(false);
        }
    }

}
