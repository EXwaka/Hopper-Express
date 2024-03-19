using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Crow : MonoBehaviour
{
    public float moveSpeed = 2f;
    public GameObject player;

    private void Start()
    {

    }

    void Update()
    {
        if (player != null)
        {
            Vector3 currentPosition = transform.position;

            Vector3 targetPosition = new Vector3(player.transform.position.x, 0f+3, 0f);

            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
        }



    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ( "floorspike"))
        {
            moveSpeed /= 2;
        }
        if (other.CompareTag ( "MonsterAttackRange"))
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
        if (other.CompareTag(  "MonsterAttackRange"))
        {
            moveSpeed = 1.5f;
        }
    }



}
