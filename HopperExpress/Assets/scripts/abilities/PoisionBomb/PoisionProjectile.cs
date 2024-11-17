using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisionProjectile : MonoBehaviour
{
    public float jumpForce = 0.1f;
    public GameObject poisionArea;
    public Transform SpawnPoint;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.down * jumpForce, ForceMode.Impulse);

    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("HitOnFloor", true);
            Instantiate(poisionArea, SpawnPoint.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
