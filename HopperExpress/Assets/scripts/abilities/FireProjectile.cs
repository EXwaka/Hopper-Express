using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public float jumpForce = 0.1f;
    public GameObject FireArea;
    public Transform SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            GetComponent<Rigidbody>().AddForce(Vector3.down * jumpForce, ForceMode.Impulse);

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        Instantiate(FireArea, SpawnPoint.position, Quaternion.identity);
    //        Destroy(this.gameObject);
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            Instantiate(FireArea, SpawnPoint.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
