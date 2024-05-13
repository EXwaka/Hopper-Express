using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public GameObject core;
    public int HPmax_core=100;
    public int HPcurrent_core;
    public HBbar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        HPcurrent_core = HPmax_core;
        healthBar.SetMaxHealth(HPmax_core);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("coreHP: " + HP_core);
        if (HPcurrent_core <= 0)
        {

            Destroy(this.gameObject);
        
        }
    }

    public void GetHit(int damage)
    {
        HPcurrent_core -= damage;
        healthBar.SetHealth(HPcurrent_core);
    }


}
