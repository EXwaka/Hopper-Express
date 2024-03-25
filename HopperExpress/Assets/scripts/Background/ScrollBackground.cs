using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 startPosition;
    public int repeatWhen=50;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time*speed,repeatWhen);

        transform.position = startPosition + Vector3.right * newPosition;
    }
}
