using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public GameObject core;
    public static float HP_core=100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("coreHP: " + HP_core);
        if (HP_core <= 0)
        {

            Destroy(this.gameObject);
        
        }
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Slime")
    //    {
    //        HP_core--;
    //        Destroy(other.gameObject);
    //    }
    //}
}
