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


    private void Start()
    {
        ableToMove = true;
        UpdateKeyBindings();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;

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
            // �����e����Ψ�Ҧ��l���� SpriteRenderer
            SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

            // �M���Ҧ� SpriteRenderer�A�ñN���̪� enabled �]�m�� false
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

            float currentSpeed = onsTacleControl3.Storming ? 1.5f : 10f;  // �p�G���ɱҰ� �t�׬�1.5 �_�h��10
            if (Input.GetKey(moveRKey))
            {

                moveRight = true;
                if (flying && !isGrounded)
                {

                    GetComponent<Rigidbody>().AddForce(Vector3.right * 30f);

                }
                else if (onsTacleControl3.Storming)
                {

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
                    //Move(Vector3.left, 4.5f);
                    GetComponent<Rigidbody>().AddForce(Vector3.left * 30f);
                }
                else if (onsTacleControl3.Storming)
                {

                    Move(Vector3.left, 10 + currentSpeed);
                }

                Move(Vector3.left,moveSpeed);
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

        // ����ĪG
        activeJet = false;
    }
    void Down()
    {
        if (flying)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.down * jumpForce*2, ForceMode.Acceleration);

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
