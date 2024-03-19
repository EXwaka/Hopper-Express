using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    float JumpTime;
    public float JumpForce = 12f;
    public GameObject player;

    private void Start()
    {
        JumpTime = 0;
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 currentPosition = transform.position;

            Vector3 targetPosition = new Vector3(player.transform.position.x, 0f, 0f);

            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
        }


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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("floorspike"))
        {
            moveSpeed /= 2;
        }
        if (other.CompareTag("MonsterAttackRange"))
        {
            moveSpeed = 0;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("floorspike"))
        {
            moveSpeed *= 2;
        }
        if (other.CompareTag("MonsterAttackRange"))
        {
            moveSpeed = 1.5f;
        }
    }



}
