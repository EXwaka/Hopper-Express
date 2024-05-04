using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMonster : MonoBehaviour
{
    public GameObject target;

    private void Start()
    {
    }

    void Update()
    {


    }
    void FixedUpdate()
    {

        GetComponent<Rigidbody>().AddForce(Vector3.down * 30f);
    }


}
