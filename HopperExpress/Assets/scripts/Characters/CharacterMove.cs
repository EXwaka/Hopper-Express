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
    private SpriteRenderer spriteRenderer;
    private bool ableToMove = true;
    public static CharacterMove instance;
    public bool flying;
    public GameObject jetpack;
    public bool activeJet;

    Rigidbody rb;

    private void Start()
    {
        ableToMove = true;
        UpdateKeyBindings();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;

        rb = GetComponent<Rigidbody>();
        activeJet = false;
        if (Skills.skill_jetpack)
        {
            jetpack.SetActive(true);
            flying = true;
        }
        else
        {
            jetpack.SetActive(false);
            flying = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(jumpKey) && ableToMove)
        {
            Jump();
            Fly();
        }
        if (TrainMoneAnim.TrainGo)
        {
            ableToMove=false;
            // 獲取當前物件及其所有子物件的 SpriteRenderer
            SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

            // 遍歷所有 SpriteRenderer，並將它們的 enabled 設置為 false
            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                spriteRenderer.enabled = false;
            }
        }
  
    }

    void FixedUpdate()
    {
        if(ableToMove)
        {

            float currentSpeed = onsTacleControl3.Storming ? 1.5f : moveSpeed;  // 如果風暴啟動 速度為1.5 否則為10
            if (Input.GetKey(moveRKey))
            {

                moveRight = true;
                if (flying && !isGrounded)
                {

                    rb.velocity=new Vector3(15,0,0);

                }
                if (onsTacleControl3.Storming)
                {
                    if(flying)
                    {
                        rb.velocity = new Vector3(15, 0, 0);

                    }
                    Move(Vector3.right, currentSpeed);

                }
                Move(Vector3.right, currentSpeed);
                GetComponent<SpriteRenderer>().flipX = false;

                jetpack.GetComponent<SpriteRenderer>().flipX = false;//jetpack
                jetpack.transform.localPosition = new Vector3(-0.32f, jetpack.transform.localPosition.y, jetpack.transform.localPosition.z);
            }
            else if (Input.GetKey(moveLKey))
            {
                moveRight = false;
                if (flying && !isGrounded)
                {

                    rb.velocity = new Vector3(-15, 0, 0);

                }
                else if (onsTacleControl3.Storming)
                {

                    Move(Vector3.left, 10 + currentSpeed);
                }

                Move(Vector3.left,currentSpeed);
                GetComponent<SpriteRenderer>().flipX = true;

                jetpack.GetComponent<SpriteRenderer>().flipX = true;//jetpack
                jetpack.transform.localPosition = new Vector3(0.32f, jetpack.transform.localPosition.y, jetpack.transform.localPosition.z);

            }
            else
            {
                StopMove();
            }

            if(Input.GetKey(KeyCode.S))
            {
                Down();
            }
            if (!flying)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.down * 50f);
            }
        }

    }

    void Move(Vector3 direction, float speed)
    {

        animator.SetBool("IsWalking", true);
        transform.Translate(direction * speed * Time.fixedDeltaTime);
    }

    void StopMove()
    {
        animator.SetBool("IsWalking", false);
    }

    void Jump()
    {
        if(isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void Fly()
    {
        if (flying&&!isGrounded)
        {
            StartCoroutine(Jeting());
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce / 1.5f, ForceMode.Impulse);
        }


    }
    private IEnumerator Jeting()
    {
        activeJet = true;
        yield return new WaitForSeconds(2);

        // 停止效果
        activeJet = false;
    }
    void Down()
    {
        if (flying)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.down * jumpForce*3, ForceMode.Acceleration);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AnimationStop"))
        {
            Debug.Log("HitWall");
            TrainMoneAnim.TrainGo = false;

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
