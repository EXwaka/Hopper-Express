using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 20f;
    private bool isGrounded;
    public Animator animator;
    public static bool moveRight = true;
    private KeyCode jumpKey;

    public static CharacterMove instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        jumpKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("JumpKey", KeyCode.Space.ToString()));
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(jumpKey);

        if (Input.GetKeyDown(jumpKey) && isGrounded==true)
        {
            Jump();
        }
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
        else
        {
            StopMove();
        }

        // Apply a downward force to simulate gravity
        GetComponent<Rigidbody>().AddForce(Vector3.down * 50f);
    }

    void Move(Vector3 direction)
    {
        animator.SetBool("IsWalking", true);
        transform.Translate(direction * moveSpeed * Time.fixedDeltaTime);
    }

    void StopMove()
    {
        animator.SetBool("IsWalking", false);

    }

    void Jump()
    {
        // Add a force in the upward direction to simulate jumping
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

    }

    public void UpdateKeyBindings()
    {
        jumpKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("JumpKey", KeyCode.Space.ToString()));
    }

}
