using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grallhopperMinions : MonoBehaviour
{
    float moveSpeed;
    public GameObject target;
    private MonsterManager monsterManager;

    private void Start()
    {
        monsterManager = GetComponent<MonsterManager>();
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

        if (other.gameObject.TryGetComponent<Core>(out Core core))
        {
            //Debug.Log("HitCore");
            core.GetHit(15);
            monsterManager.Death();
            //Destroy(gameObject);
            //Wavespawner.monsCount--;

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
