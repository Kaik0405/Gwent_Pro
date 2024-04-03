using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Drag drg = eventData.pointerDrag.GetComponent<Drag>();
        if (drg != null)
        {
            drg.parentReturn = this.transform;
        }
    }

}
