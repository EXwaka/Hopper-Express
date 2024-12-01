using UnityEngine;

public class IceBurst : MonoBehaviour
{
    public float fallSpeed = 5f; 
    public Animator animator;
    private bool hasHitGround = false;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (!hasHitGround)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Ground" && !hasHitGround)
        {
            FindObjectOfType<AudioManager>().Play("iceBurst");

            hasHitGround = true;
            animator.SetTrigger("Hit"); 
            Destroy(gameObject, 8f); 
        }
    

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("slip");
            CharacterMove character = other.GetComponent<CharacterMove>();
            if (character != null)
            {
                character.ReverseControls(3f);
            }
            Destroy(gameObject); 

        }
        if (other.gameObject.tag == "Player2")
        {
            hasHitGround = true;
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("iceBurst");

        }
    }
}
