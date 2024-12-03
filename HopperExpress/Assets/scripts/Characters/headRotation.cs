using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headRotation : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    private SpriteRenderer spriteRenderer;
    public float flipX=0.02f;
    public float flipY=0.75f;
    //public float ang1 = -30;
    //public float ang2 = 30;
    //public float ang3=140;
    //public float ang4=180;
    //public float ang5=-179;
    //public float ang6=-140;
    public float rotationSpeed = 10f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -mainCam.transform.position.z;
        Vector3 targetPosition = mainCam.ScreenToWorldPoint(mousePosition);
        targetPosition.z = 0f;
        Vector3 directionToMouse = targetPosition - transform.position;
        float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

            //Quaternion rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0f, 0f, angle)), Time.deltaTime * rotationSpeed);

            //transform.rotation = rotation;

            if (directionToMouse.x < 0)
            {
                spriteRenderer.flipX = true;
                transform.localPosition = new Vector3(0, flipY, 0);
        }
            else
            {
                spriteRenderer.flipX = false;
                transform.localPosition = new Vector3(0, flipY, 0);
        }
        //}

    }
}
