using System;
using UnityEngine.EventSystems;

public class Cell : Entity, IPointerClickHandler
{
    public static Action<Coordinates> OnClickedCell;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;
        var par = this.transform.parent.GetComponent<Entity>();
        var prapar = par.transform.parent.GetComponent<Entity>();
        
        OnClickedCell?.Invoke(new Coordinates
        {
            Col = position,
            Row = par.position,
            Cut = prapar.position
        });
    }
}
