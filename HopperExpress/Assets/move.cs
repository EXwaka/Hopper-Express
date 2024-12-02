using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Transform pointA; 
    public Transform pointB; 
    public GameObject objectToMove; 

    public float duration = 15f; 

    void Start()
    {
        StartCoroutine(MoveOverTime());
    }

    private IEnumerator MoveOverTime()
    {
        float elapsedTime = 0f;

        Vector3 startPos = pointA.position;
        Vector3 endPos = pointB.position;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;

            objectToMove.transform.position = Vector3.Lerp(startPos, endPos, t);

            yield return null; 
        }

        objectToMove.transform.position = endPos;
    }
}
