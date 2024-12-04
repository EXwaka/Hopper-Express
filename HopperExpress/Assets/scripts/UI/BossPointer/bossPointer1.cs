using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossPointer1 : MonoBehaviour
{
    public Transform player;   
    public Transform boss;      
    public RectTransform arrow;  
    public RectTransform marker;   
    public Canvas canvas;      
    public float screenEdgeOffset = 50f; 
    public float markerEdgeOffset = 70f; 

    void Update()
    {
        if (!boss || !player) return;

        Vector3 directionToBoss = player.position - boss.position;

        float angle = Mathf.Atan2(directionToBoss.y, directionToBoss.x) * Mathf.Rad2Deg;
        arrow.rotation = Quaternion.Euler(0, 0, angle - 90); 

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(boss.position);

        bool isBossOnScreen = screenPosition.z > 0 &&
                              screenPosition.x > 0 && screenPosition.x < Screen.width &&
                              screenPosition.y > 0 && screenPosition.y < Screen.height;

        if (isBossOnScreen)
        {
            arrow.gameObject.SetActive(false);
            marker.gameObject.SetActive(false);
        }
        else
        {
            arrow.gameObject.SetActive(true);
            marker.gameObject.SetActive(true);

            Vector3 clampedArrowPosition = screenPosition;
            clampedArrowPosition.x = Mathf.Clamp(screenPosition.x, screenEdgeOffset, Screen.width - screenEdgeOffset);
            clampedArrowPosition.y = Mathf.Clamp(screenPosition.y, screenEdgeOffset, Screen.height - screenEdgeOffset);

            Vector3 clampedMarkerPosition = screenPosition;
            clampedMarkerPosition.x = Mathf.Clamp(screenPosition.x, markerEdgeOffset, Screen.width - markerEdgeOffset);
            clampedMarkerPosition.y = Mathf.Clamp(screenPosition.y, markerEdgeOffset, Screen.height - markerEdgeOffset);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.GetComponent<RectTransform>(),
                clampedArrowPosition,
                canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : Camera.main,
                out Vector2 arrowLocalPosition
            );
            arrow.localPosition = arrowLocalPosition;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.GetComponent<RectTransform>(),
                clampedMarkerPosition,
                canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : Camera.main,
                out Vector2 markerLocalPosition
            );
            marker.localPosition = markerLocalPosition;
        }
    }
}
