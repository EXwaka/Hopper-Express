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

        // 使用 ScreenToWorldPoint 將滑鼠位置轉換為世界空間位置
        Vector3 worldMousePosition = mainCam.ScreenToWorldPoint(mousePosition);

        // 直接設置物體的位置
        transform.position = new Vector3(worldMousePosition.x, worldMousePosition.y, transform.position.z);
    }
}
