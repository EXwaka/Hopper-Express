using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemleonMinion : MonoBehaviour
{
    public GameObject Explosion;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Wavespawner.monsCount += 1;
        animator = GetComponent<Animator>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("HitGround", true);
            GameObject explosionInstance = Instantiate(Explosion, transform.position, transform.rotation);

            Destroy(explosionInstance, 0.2f);
        }
    }

}
