using UnityEngine;
using UnityEngine.EventSystems;

public class cursorObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CursorManager.CursorType cursorType;

    public void OnPointerEnter(PointerEventData eventData)
    {
        CursorManager.Instance.SetActiveCursorAnimation(cursorType);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CursorManager.Instance.SetActiveCursorAnimation(CursorManager.CursorType.Aim);
    }
}
