using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    public int damage = 2; 

    private void Start()
    {
        Destroy(gameObject,3);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Core>(out Core core))
        {
            //play "explode" animation
            core.GetHit(damage);
            Destroy(gameObject);
        }
        
    }

}
