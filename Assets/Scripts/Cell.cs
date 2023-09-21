using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : Entity, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        var par = this.transform.parent.GetComponent<Entity>();
        var prapar = par.transform.parent.GetComponent<Entity>();
        
        Debug.Log($"Position is col:{position} row:{par.position} cut:{prapar.position}");
    }
}
