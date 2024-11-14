using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R3D2Control : MonoBehaviour
{
    MonsterManager monsterManager;
    public GameObject bullet;
    private Transform target;
    public float bulletSpeed=15;
    public Transform FirePoint;
    private bool Attacking = false;
    private float CD = 2;
    public float CDMax = 2;
    // Start is called before the first frame update
    void Start()
    {
        Attacking = false;
        monsterManager = GetComponent<MonsterManager>();

        Core core = FindObjectOfType<Core>();
        if (core != null)
        {
            target = core.transform; // Set target to the Core's transform
        }
        else
        {
            Debug.LogError("Core not found in the scene.");
            Destroy(gameObject); // Destroy bullet if there is no core
        }
    }
    private void Update()
    {
        if (Attacking)
        {
            CD -=Time.deltaTime;
            if (CD <= 0)
            {
                Shoot();
                CD = CDMax;
            }

        }
    }

    void FixedUpdate()
    {

        GetComponent<Rigidbody>().AddForce(Vector3.down * 30f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AttackArea"))
        {
            //Debug.Log("HitWall");
            monsterManager.moveSpeed = 0;
            monsterManager.moveSpeedMax = 0;
            Attacking =true;
        }

    }

    void Shoot()
    {
        if (target != null&&!monsterManager.Freeze)
        {
            GameObject newBullet = Instantiate(bullet, FirePoint.transform.position, Quaternion.identity);

            // Calculate the direction to the target
            Vector3 direction = (target.transform.position - transform.position).normalized;
            direction.z = 0;

            newBullet.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
        }
    }


}
