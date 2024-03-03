using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public Transform subject;

    Vector2 startPosition;
    float startZ;

    Vector2 travel =>(Vector2)cam.transform.position-startPosition;
    float parallaxFactor=> Mathf.Abs(distanceFromSubject)/clippingPlane;

    float distanceFromSubject=> transform.position.z-subject.position.z;
    float clippingPlane=> (cam.transform.position.z+(distanceFromSubject>0? cam.farClipPlane:cam.nearClipPlane));
  
    public void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
    }

    // Update is called once per frame
    public void Update()
    {
        Vector2 newPos = startPosition+travel;
        transform.position = new Vector3(newPos.x,newPos.y,startZ);
    }
}
