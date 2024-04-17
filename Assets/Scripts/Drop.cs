using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drop : MonoBehaviour, IDropHandler
{
    private AudioSource audioActivCard;
    static public bool invoke = false;

    void Start()
    {
        audioActivCard = GetComponent<AudioSource>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Drag drg = eventData.pointerDrag.GetComponent<Drag>();
        if (drg != null)
        {

            ControlPanels controlPanels = GetComponent<ControlPanels>();
            if (controlPanels != null && controlPanels.CanPlaceCard(drg.cardType, drg.cardFact))
            {
                drg.parentReturn = this.transform;

                controlPanels.AddCardToPanelHand(eventData.pointerDrag);
                if (drg.previusPanel != null)
                {
                    ControlPanels previusPanelsControl = drg.previusPanel.GetComponent<ControlPanels>();
                    if (previusPanelsControl != null)
                    {
                        previusPanelsControl.cardInPanel.Remove(eventData.pointerDrag);
                    }
                }
                if (audioActivCard != null)
                {
                    audioActivCard.Play();
                }
            }
        }
    }
}
