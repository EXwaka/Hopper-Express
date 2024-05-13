using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class hoverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject skillSlot;
    public void OnPointerEnter(PointerEventData eventData)
    {
        skillSlot.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        skillSlot.SetActive(false);

    }
}
