using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    private SpriteRenderer spriteRenderer; 

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            // ����ƹ���m�P�����m����V
            Vector3 directionToMouse = raycastHit.point - transform.position;
            directionToMouse.z = 0f; // �N Z �b�]�m�� 0�A�u�O�d X �M Y ��V

            // �ϥ� Mathf.Atan2 �p����઺����
            float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

            // �ϥ� Quaternion.Euler �Ы� Z �b�W������
            Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

            // �N���骺����]�m���p�⪺����
            transform.rotation = rotation;

            // �譱���ફ�󪺹Ϥ�
            if (directionToMouse.x < 0)
            {
                spriteRenderer.flipY = true;
            }
            else
            {
                spriteRenderer.flipY = false;
            }
        }
    }
}