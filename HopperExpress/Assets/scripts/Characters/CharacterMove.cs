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
    static public bool ableToMove = true;
    public static CharacterMove instance;
    public bool flying;
    public GameObject jetpack;
    public bool activeJet;
    private Coroutine reverseCoroutine; 

    Rigidbody rb;
    static public bool inChaos;

    private void Start()
    {
        onsTacleControl3.Storming = false;
        inChaos = false;
        ableToMove = false;
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
        Invoke("StartMove", 5.5f);
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
            ableToMove = false;
            SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                spriteRenderer.enabled = false;
            }
        }

    }

    void FixedUpdate()
    {
        if (ableToMove)
        {

            float currentSpeed = onsTacleControl3.Storming ? 1.5f : moveSpeed;  // 如果風暴啟動 速度為1.5 否則為10
            if (Input.GetKey(moveRKey))
            {
                moveRight = true;
                if (flying && !isGrounded)
                {
                    rb.velocity = new Vector3(15, 0, 0);
                }
                if (onsTacleControl3.Storming)
                {
                    if (flying)
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
                    Move(Vector3.left, 15 + currentSpeed);
                }

                Move(Vector3.left, currentSpeed);
                GetComponent<SpriteRenderer>().flipX = true;

                jetpack.GetComponent<SpriteRenderer>().flipX = true;//jetpack
                jetpack.transform.localPosition = new Vector3(0.32f, jetpack.transform.localPosition.y, jetpack.transform.localPosition.z);

            }
            else
            {
                StopMove();
            }

            if (Input.GetKey(KeyCode.S))
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
        if(!isGrounded&&Skills.skill_jetpack)
        {
            animator.SetBool("Flying", true);
        }
        animator.SetBool("IsWalking", true);
        transform.Translate(direction * speed * Time.fixedDeltaTime);
    }

    void StopMove()
    {
        animator.SetBool("IsWalking", false);
    }

    void Jump()
    {
        if (isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void Fly()
    {
        if (flying && !isGrounded)
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
            GetComponent<Rigidbody>().AddForce(Vector3.down * jumpForce * 3, ForceMode.Acceleration);

        }
    }
    void StartMove()
    {
        ableToMove = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            animator.SetBool("Flying", false);
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
            TrainMoneAnim.TrainGo = false;

        }
    }

    public void ReverseControls(float duration)
    {
        if (reverseCoroutine != null)
        {
            StopCoroutine(reverseCoroutine); 
        }
        reverseCoroutine = StartCoroutine(ReverseDirectionCoroutine(duration)); 
    }

    private IEnumerator ReverseDirectionCoroutine(float duration)
    {
        inChaos = true;
        moveSpeed = -Mathf.Abs(moveSpeed); 
        yield return new WaitForSeconds(duration);
        inChaos = false;

        moveSpeed = Mathf.Abs(moveSpeed); 
        reverseCoroutine = null; 
    }


    public void UpdateKeyBindings()
    {
        jumpKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("JumpKey", KeyCode.Space.ToString()));
        moveRKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveRKey", KeyCode.D.ToString()));
        moveLKey = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveLKey", KeyCode.A.ToString()));
        //Debug.Log("Updated bindings: JumpKey = " + jumpKey + ", MoveRKey = " + moveRKey);
    }
}