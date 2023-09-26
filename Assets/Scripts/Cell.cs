using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : Entity, IPointerClickHandler
{
    public static Action<Coordinates, Cell> OnClickedCell;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        //TODO добавить изменение ячейки в соответсвии с указанным игроком
        
        if (eventData.button != PointerEventData.InputButton.Left) return;
        var par = this.transform.parent.GetComponent<Entity>();
        var prapar = par.transform.parent.GetComponent<Entity>();

        OnClickedCell?.Invoke(new Coordinates
        {
            Col = position,
            Row = par.position,
            Cut = prapar.position
        }, this);
    }
}
