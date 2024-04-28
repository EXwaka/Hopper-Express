using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpike : MonoBehaviour
{
    public GameObject floorspike;


    // Start is called before the first frame update
    void Start()
    {
        //copy the code in void update to here once the game complete



    }

    // Update is called once per frame
    void Update()
    {
        //if (Skills.skill_floorspike == true)
        //{
        //    floorspike.SetActive(true);
        //}
        //else if (Skills.skill_floorspike == false)
        //{
        //    floorspike.SetActive(false);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {

    }
    private void OnTriggerExit(Collider other)
    {

    }
}
