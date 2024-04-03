using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour,IDragHandler,IEndDragHandler,IBeginDragHandler
{
    Transform parentReturn = null;
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentReturn = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
    }
    public void OnDrag (PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentReturn);
    }

    
}
