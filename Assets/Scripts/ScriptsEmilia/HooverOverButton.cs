using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HooverOverButton : Button
{
    //Todo change to SO event
    public Action OnHooverEnter;
    public Action OnHooverExit;
    
    public override void OnPointerEnter(PointerEventData eventData)
    {
        OnHooverEnter?.Invoke();
    }
    
    public override void OnPointerExit(PointerEventData eventData)
    {
        OnHooverExit?.Invoke();
    }
}
