using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpike : MonoBehaviour
{
    public GameObject floorspike;
    

    // Start is called before the first frame update
    void Start()
    {
        if (Skills.skill_floorspike == true)
        {
            floorspike.SetActive(true);
        }
        else
        {
            floorspike.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

    }
    private void OnTriggerExit(Collider other)
    {

    }
}
