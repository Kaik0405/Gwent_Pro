using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drop : MonoBehaviour, IDropHandler
{
    private AudioSource audioActivCard;
    static public bool invoke = false;
    private GameObject cardDrop;
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
                EffectActive(cardis, cardis2,eventData.pointerDrag,controlPanels.gameObject);
            }
        }
    }
    private void EffectActive(DisplayCard card1, DisplayCard2 card2,GameObject eventData,GameObject panelObject)
    {
        if(card1 != null)
        {
            if((card1.currentCard.ID == 12)||(card1.currentCard.ID == 13)||(card1.currentCard.ID == 14))
                card1.currentCard.effect(eventData);

            if (card1.currentCard.ID == 15)
                card1.currentCard.effect(panelObject);   
            
            if((card1.currentCard.ID == 02)||(card1.currentCard.ID == 05))
                card1.currentCard.effect(GameManager.player1);
            
            if(card1.currentCard.ID == 1)
                card1.currentCard.effect(eventData,GameManager.player2);
         
            if(card1.currentCard.ID == 4)
                card1.currentCard.effect(GameManager.player1, GameManager.player2);
        }
        if(card2 != null)
        {
            if ((card2.currentCard2.ID == 12) || (card2.currentCard2.ID == 13) || (card2.currentCard2.ID == 14) || (card2.currentCard2.ID == 15))
                card2.currentCard2.effect(eventData);

            if (card2.currentCard2.ID == 15)
                card2.currentCard2.effect(panelObject);

            if ((card2.currentCard2.ID == 02) || (card2.currentCard2.ID == 05))
                card2.currentCard2.effect(GameManager.player2);

            if (card2.currentCard2.ID == 1)
                card2.currentCard2.effect(eventData, GameManager.player1);

            if (card2.currentCard2.ID == 4)
                card2.currentCard2.effect(GameManager.player2, GameManager.player1);
        }
    }
}
