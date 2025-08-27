using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTip_UI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] string message;

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipManager._instance.SetAndShowToolTip(message);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager._instance.HideToolTip();
    }
}
