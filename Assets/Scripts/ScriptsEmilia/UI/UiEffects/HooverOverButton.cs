using System;
using UnityEngine.EventSystems;
using Button = UnityEngine.UI.Button;

public class HooverOverButton : Button
{
    //Todo change to SO event?? but then all will listen?
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
