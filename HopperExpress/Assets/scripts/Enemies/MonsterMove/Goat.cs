using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goat : MonoBehaviour
{
    float JumpTime;
    public float JumpForce = 8f;

    private void Start()
    {
        JumpTime = 0;
    }

    void Update()
    {


        JumpTime += Time.deltaTime;
        if (JumpTime >= 3)
        {
            Jump();
            JumpTime = 0;

        }

    }
    void FixedUpdate()
    {

        GetComponent<Rigidbody>().AddForce(Vector3.down * 30f);
    }
    void Jump()
    {
        // Add a force in the upward direction to simulate jumping
        GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce, ForceMode.Impulse);


    }

}
