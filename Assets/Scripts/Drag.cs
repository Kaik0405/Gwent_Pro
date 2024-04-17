using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour,IDragHandler,IEndDragHandler,IBeginDragHandler
{
    public Transform parentReturn = null;
    public Card.typefield cardType;
    public Card.typefaction cardFact;
    public GameObject previusPanel;
    public Player cardPlayer;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (cardPlayer.turn)
        {
            parentReturn = this.transform.parent;
            previusPanel = parentReturn.gameObject;
            this.transform.SetParent(this.transform.parent.parent);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }
    public void OnDrag (PointerEventData eventData)
    {
        if (cardPlayer.turn)
        {
            transform.position = eventData.position;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (cardPlayer.turn)
        {
            this.transform.SetParent(parentReturn);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }  
}
