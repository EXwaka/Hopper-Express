using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    private SpriteRenderer spriteRenderer;
    //public GameObject gun; 
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            Vector3 directionToMouse = raycastHit.point - transform.position;
            directionToMouse.z = 0f; 

            float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

            // rotate
            transform.rotation = rotation;

            // reflect image
            if (directionToMouse.x < 0)
            {
                spriteRenderer.flipY = true;
                //gun.transform.localPosition = new Vector3(-0.3f, 0, 0);
            }
            else
            {
                spriteRenderer.flipY = false;
                //gun.transform.localPosition = new Vector3(+0.3f, 0, 0);

            }
        }
    }
}
