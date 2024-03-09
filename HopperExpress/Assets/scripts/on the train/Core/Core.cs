using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public GameObject core;
    public static int HP_core=3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP_core <= 0)
        {
            Destroy(this.gameObject);
        
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Slime")
        {
            HP_core--;
            Destroy(other.gameObject);
        }
    }
}
