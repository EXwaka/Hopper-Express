using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headRotation : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    private SpriteRenderer spriteRenderer;
    public float flipX=0.02f;
    public float flipY=0.75f;
    public float ang1=-30;
    public float ang2=30;
    public float ang3=140;
    public float ang4=180;
    public float ang5=-179;
    public float ang6=-140;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -mainCam.transform.position.z; // 確保 z 軸值為負相機位置

        // 將滑鼠位置轉換為世界空間座標
        Vector3 targetPosition = mainCam.ScreenToWorldPoint(mousePosition);
        targetPosition.z = 0f; // 將 z 軸設置為 0，與物體在同一平面上

        // 計算物體與滑鼠位置之間的方向
        Vector3 directionToMouse = targetPosition - transform.position;

        float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);
        // 檢查角度是否在允許範圍內
        if ((angle > ang1 && angle < ang2) || (angle > ang3 && angle < ang4) || (angle > ang5 && angle < ang6))
        {
            Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

            transform.rotation = rotation;

            if (directionToMouse.x < 0)
            {
                spriteRenderer.flipY = true;
                transform.localPosition = new Vector3(flipX, flipY, 0);
            }
            else
            {
                spriteRenderer.flipY = false;
                transform.localPosition = new Vector3(-flipX, flipY, 0);
            }
        }
    }
}
