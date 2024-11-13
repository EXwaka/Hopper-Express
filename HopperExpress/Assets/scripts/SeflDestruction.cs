using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeflDestruction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 5);
    }
    void DestroySelf()
    {
        Destroy(gameObject);
    }
 
}
