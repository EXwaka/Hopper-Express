using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField] private Camera mainCam;

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = transform.position.z - mainCam.transform.position.z;

        // �ϥ� ScreenToWorldPoint �N�ƹ���m�ഫ���@�ɪŶ���m
        Vector3 worldMousePosition = mainCam.ScreenToWorldPoint(mousePosition);

        // �����]�m���骺��m
        transform.position = new Vector3(worldMousePosition.x, worldMousePosition.y, transform.position.z);
    }
}
