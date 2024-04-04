    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class Drop : MonoBehaviour,IDropHandler
    {
        public ControlPanels controlPanels;
        public void OnDrop(PointerEventData eventData)
        {
            Drag drg = eventData.pointerDrag.GetComponent<Drag>();
            if (drg != null)
            {
                if (controlPanels.CanPlaceCard(drg.cardType))
                {
                    drg.parentReturn = this.transform;
                }
            }
        }

    }
