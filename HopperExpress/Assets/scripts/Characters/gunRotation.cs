using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    private SpriteRenderer spriteRenderer;
    public float flipX;
    public float flipY;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -mainCam.transform.position.z; // �T�O z �b�Ȭ��t�۾���m

        // �N�ƹ���m�ഫ���@�ɪŶ��y��
        Vector3 targetPosition = mainCam.ScreenToWorldPoint(mousePosition);
        targetPosition.z = 0f; // �N z �b�]�m�� 0�A�P����b�P�@�����W

        // �p�⪫��P�ƹ���m��������V
        Vector3 directionToMouse = targetPosition - transform.position;

        float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        // rotate
        transform.rotation = rotation;

        // reflect image
        if (directionToMouse.x < 0)
        {
            spriteRenderer.flipY = true;
            transform.localPosition = new Vector3(flipX, 0.5f, 0);
        }
        else
        {
            spriteRenderer.flipY = false;
            transform.localPosition = new Vector3(-flipX, 0.5f, 0);
        }
    }
}
