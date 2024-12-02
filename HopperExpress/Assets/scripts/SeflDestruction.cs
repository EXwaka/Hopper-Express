using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeflDestruction : MonoBehaviour
{
    public float sec=5;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", sec);
    }
    void DestroySelf()
    {
        Destroy(gameObject);
    }
 
}
