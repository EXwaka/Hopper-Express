using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{
    public float knockbackForce = 200f;
    private int Damage = 5;

    private void Start()
    {
        Destroy(gameObject,1.1f);
    }
    private void Update()
    {
        transform.Translate(Vector3.left * 10 * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        CharacterMove characterMove = other.GetComponent<CharacterMove>();

        if (characterMove != null)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                float moveSpeed = characterMove.moveSpeed;
                float totalKnockback = knockbackForce + moveSpeed * 2; 

                rb.AddForce(new Vector3(-totalKnockback, 0, 0), ForceMode.Impulse);
            }
        }
        Core core = other.GetComponent<Core>();  
        if (core != null)
        {
            core.GetHit(Damage);
        }

    }
}
