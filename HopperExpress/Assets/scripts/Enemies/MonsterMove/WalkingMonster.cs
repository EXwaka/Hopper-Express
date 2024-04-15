using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMonster : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public GameObject target;

    private void Start()
    {
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 currentPosition = transform.position;

            Vector3 targetPosition = new Vector3(target.transform.position.x, 0f, 0f);

            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
        }

    }
    void FixedUpdate()
    {

        GetComponent<Rigidbody>().AddForce(Vector3.down * 30f);
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
            moveSpeed = 2.5f;
        }
    }
}
