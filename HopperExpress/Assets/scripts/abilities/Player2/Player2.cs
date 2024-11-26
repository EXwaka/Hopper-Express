using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player2 : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletPrefeb;
    private float bulletSpeed = 20f;
    public Transform SpawnPoint;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (!Skills.skill_player2)
        {
            player.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(Vector3.right, 3);
            GetComponent<SpriteRenderer>().flipX = false;

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {

            Move(Vector3.left, 3);
            GetComponent<SpriteRenderer>().flipX = true;

        }
        else
        {
            StopMove();
        }

        if (Input.GetKeyDown(KeyCode.L)|| Input.GetKeyDown(KeyCode.Keypad0))
        {
            Attack();
        }
    }
    void Move(Vector3 direction, float speed)
    {

        animator.SetBool("Walking", true);
        transform.Translate(direction * speed * Time.fixedDeltaTime);
    }
    void StopMove()
    {
        animator.SetBool("Walking", false);
    }
    void Attack()
    {
        FindObjectOfType<AudioManager>().Play("CatAttack");

        SpawnBullet();

    }
    void SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefeb, SpawnPoint.position, Quaternion.identity);

        Vector3 direction = Vector3.right; 
        Vector3 bulletScale = bullet.transform.localScale; 

        if (GetComponent<SpriteRenderer>().flipX)
        {
            direction = Vector3.left;
            bulletScale.x = -Mathf.Abs(bulletScale.x); 
        }
        else
        {
            bulletScale.x = Mathf.Abs(bulletScale.x); 
        }

        bullet.transform.localScale = bulletScale; 

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }

    }




}
