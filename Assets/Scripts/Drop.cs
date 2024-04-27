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
        DisplayCard cardis = eventData.pointerDrag.GetComponent<DisplayCard>();
        DisplayCard2 cardis2 = eventData.pointerDrag.GetComponent<DisplayCard2>();
        if (drg != null)
        {

            ControlPanels controlPanels = GetComponent<ControlPanels>();
            if (controlPanels != null && controlPanels.CanPlaceCard(drg.cardType,drg.cardFact,cardis,cardis2,eventData.pointerDrag))
            {
                drg.parentReturn = this.transform;
                if(cardis != null)       //si la carta esta en el campo se desactiva el cardBack DC1
                {
                    cardis.onField = true;
                }
                if(cardis2 != null)  //si la carta esta en el campo se desactiva el cardBack DC2
                {
                    cardis2.onField2 = true;
                }

                controlPanels.AddCardToPanelHand(eventData.pointerDrag);
                invoke = true;

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
                EffectActive(cardis, cardis2);
            }
        }

    }
    private void EffectActive(DisplayCard card1, DisplayCard2 card2)
    {
        if(card1 != null)
        {
            card1.currentCard.effect();
        }
        if(card2 != null)
        {
            card2.currentCard2.effect();
        }
    }
}
