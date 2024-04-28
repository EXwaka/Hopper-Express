using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grallhopperMinions : MonoBehaviour
{
    float moveSpeed;
    public GameObject target;

    private void Start()
    {
        moveSpeed = Random.Range(3f, 8f);
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 currentPosition = transform.position;

            Vector3 targetPosition = new Vector3(target.transform.position.x, 0f + 3, 0f);

            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
        }



    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("MonsterAttackRange"))
        {
            moveSpeed = 0;
        }

    }
    //private void OnTriggerExit(Collider other)
    //{

    //    if (other.CompareTag("MonsterAttackRange"))
    //    {
    //        moveSpeed = 1.5f;
    //    }
    //}


}
