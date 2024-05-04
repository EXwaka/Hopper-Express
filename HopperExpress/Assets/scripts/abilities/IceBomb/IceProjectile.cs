using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceProjectile : MonoBehaviour
{
    public float jumpForce = 0.1f;
    public GameObject iceArea;
    public GameObject iceFog;
    public Transform SpawnPoint;
    //public Animator animator;

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
            //animator.SetBool("HitOnFloor", true);
            Instantiate(iceFog, SpawnPoint.position, Quaternion.identity);

            Instantiate(iceArea, SpawnPoint.position, Quaternion.identity);
            Destroy(this.gameObject, 0.5f);
        }
    }
}
