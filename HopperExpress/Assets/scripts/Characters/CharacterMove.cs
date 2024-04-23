using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 20f;
    public GameObject bulletPrefab; 
    public Transform bulletSpawnPoint;
    private bool isGrounded;

    public static bool moveRight = true;
    //public static bool LevelComplete = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded==true)
        {
            Jump();
        }
        //Debug.Log("CanThrowFire:" + Skills.skill_throwfire);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            moveRight = true;
            Move(Vector3.right);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveRight = false;
            Move(Vector3.left);
            GetComponent<SpriteRenderer>().flipX = true;

        }

        // Apply a downward force to simulate gravity
        GetComponent<Rigidbody>().AddForce(Vector3.down * 50f);
    }

    void Move(Vector3 direction)
    {
        transform.Translate(direction * moveSpeed * Time.fixedDeltaTime);
    }

    void Jump()
    {
        // Add a force in the upward direction to simulate jumping
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    //public static void Shoot(GameObject bulletPrefab, Transform bulletSpawnPoint)
    //{
    //    if (bulletPrefab != null && bulletSpawnPoint != null)
    //    {
    //        Vector3 mousePosition = Input.mousePosition;
    //        mousePosition.z = bulletSpawnPoint.position.z - Camera.main.transform.position.z;

    //        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

    //        Vector3 shootDirection = (worldMousePosition - bulletSpawnPoint.position).normalized;

    //        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

    //        bullet.GetComponent<Rigidbody>().velocity = shootDirection * 40f;
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        isGrounded = false;
    //    }
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "LevelComplete")
    //    {
    //        LevelComplete = true;
    //    }
    //}
}
