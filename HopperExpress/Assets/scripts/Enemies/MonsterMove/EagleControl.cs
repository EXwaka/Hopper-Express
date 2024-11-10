using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleControl : MonoBehaviour
{
    public bool AttackRange=false;
    // Start is called before the first frame update
    void Start()
    {
        AttackRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EagleAttackRange"))
        {
            FindObjectOfType<AudioManager>().Play("Eagle");
            AttackRange = true;
        }
    }
}
