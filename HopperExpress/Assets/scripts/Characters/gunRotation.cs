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
            // 拿到滑鼠位置與物體位置的方向
            Vector3 directionToMouse = raycastHit.point - transform.position;
            directionToMouse.z = 0f; // 將 Z 軸設置為 0，只保留 X 和 Y 方向

            // 使用 Mathf.Atan2 計算旋轉的角度
            float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

            // 使用 Quaternion.Euler 創建 Z 軸上的旋轉
            Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

            // 將物體的旋轉設置為計算的旋轉
            transform.rotation = rotation;

            // 鏡面反轉物件的圖片
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
