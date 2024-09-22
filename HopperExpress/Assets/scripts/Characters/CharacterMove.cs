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
    private KeyCode moveRKey;
    private KeyCode moveLKey;

    public static CharacterMove instance;

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    private void Start()
    {
        UpdateKeyBindings();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(moveRKey))
        {
            moveRight = true;
            Move(Vector3.right);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey(moveLKey))
        {
            moveRight = false;
            Move(Vector3.left);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            StopMove();
        }

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
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void UpdateKeyBindings()
    {
        jumpKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("JumpKey", KeyCode.Space.ToString()));
        moveRKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveRKey", KeyCode.D.ToString()));
        moveLKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveLKey", KeyCode.A.ToString()));
        //Debug.Log("Updated bindings: JumpKey = " + jumpKey + ", MoveRKey = " + moveRKey);
    }
}
