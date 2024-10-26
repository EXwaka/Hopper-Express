using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFog : MonoBehaviour
{
    public float destroyAfterSec = 5f;
    public float slowDownTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,destroyAfterSec);
        FindObjectOfType<AudioManager>().Play("iceFog");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<MonsterManager>(out MonsterManager enemyComponent))
        {
            enemyComponent.ColdSlow(slowDownTime);

        }
    }

}
