using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drop : MonoBehaviour, IDropHandler // Scrip de invocacion
{

    private AudioSource audioActivCard; //audio de invocacion o activacion de carta
    public GameObject audioEffect;      //audio de activacion de efecto

    static public bool invoke = false;  //detector de invocacion
    private GameObject cardDrop;

    public GameObject cardEffectBig;  // objeto al cual se le asigna la imagen de la carta al activarse su efecto
    GameObject CardP;  // objecto que hace referencia a la carta arrastrada
    Image imageCard ;  // imagen de la carta arrastrada
    Sprite spriteCard; // strite de la carta arrastrada

    void Start()
    {
        audioActivCard = GetComponent<AudioSource>();
        imageCard = cardEffectBig.GetComponent<Image>();
        spriteCard = cardEffectBig.GetComponent<Sprite>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        CardP = eventData.pointerDrag;
        Drag drg = eventData.pointerDrag.GetComponent<Drag>();
        DisplayCard cardis = eventData.pointerDrag.GetComponent<DisplayCard>();
        DisplayCard2 cardis2 = eventData.pointerDrag.GetComponent<DisplayCard2>();

        if (drg != null)
        {
            ControlPanels controlPanels = GetComponent<ControlPanels>();
            if (controlPanels != null && controlPanels.CanPlaceCard(drg.cardType, drg.cardFact, cardis, cardis2, eventData.pointerDrag)) //compruba si la carta es invocable
            {
                drg.parentReturn = this.transform;
                if (cardis != null)       //si la carta esta en el campo se desactiva el cardBack DC1
                {
                    cardis.onField = true;
                }
                if (cardis2 != null)  //si la carta esta en el campo se desactiva el cardBack DC2
                {
                    cardis2.onField2 = true;   
                }

                controlPanels.AddCardToPanelHand(eventData.pointerDrag); // agrega la carta al panel donde fue invocada
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

                AsignateImage(cardis,cardis2,CardP); 
                StartCoroutine(Retard(cardis, cardis2, eventData.pointerDrag, controlPanels.gameObject));

            }
        }
    }

    private void EffectActive(DisplayCard card1, DisplayCard2 card2, GameObject eventData, GameObject panelObject)
    {
        if (card1 != null)
        {
            if ((card1.currentCard.ID == 12) || (card1.currentCard.ID == 13) || (card1.currentCard.ID == 14) || (card1.currentCard.ID == 7) || (card1.currentCard.ID == 6)||(card1.currentCard.ID == 9))
            { card1.currentCard.effect(eventData); audioEffect.GetComponent<AudioSource>().Play(); cardEffectBig.SetActive(true); }

            else if (card1.currentCard.ID == 10)
            { card1.currentCard.effect(); audioEffect.GetComponent<AudioSource>().Play(); cardEffectBig.SetActive(true); }

            else if ((card1.currentCard.ID == 15) || (card1.currentCard.ID == 8) || (card1.currentCard.ID == 16))
            { card1.currentCard.effect(eventData); audioEffect.GetComponent<AudioSource>().Play(); cardEffectBig.SetActive(true); }

            else if ((card1.currentCard.ID == 2) || (card1.currentCard.ID == 5))
            { card1.currentCard.effect(GameManager.player1); audioEffect.GetComponent<AudioSource>().Play(); cardEffectBig.SetActive(true); }

            else if (card1.currentCard.ID == 1)
            { card1.currentCard.effect(eventData, GameManager.player2); audioEffect.GetComponent<AudioSource>().Play(); cardEffectBig.SetActive(true); }

            else if (card1.currentCard.ID == 4)
            { card1.currentCard.effect(GameManager.player1, GameManager.player2); audioEffect.GetComponent<AudioSource>().Play(); cardEffectBig.SetActive(true); }

            else if (card1.currentCard.ID == 3)
            { card1.currentCard.effect(GameManager.player1, GameManager.player2, eventData); audioEffect.GetComponent<AudioSource>().Play(); cardEffectBig.SetActive(true); }
        }
        else if (card2 != null)
        {
            if ((card2.currentCard2.ID == 12) || (card2.currentCard2.ID == 13) || (card2.currentCard2.ID == 14) || (card2.currentCard2.ID == 7)||(card2.currentCard2.ID == 6) || (card2.currentCard2.ID == 9))
            { card2.currentCard2.effect(eventData); audioEffect.GetComponent<AudioSource>().Play(); cardEffectBig.SetActive(true); }

            else if (card2.currentCard2.ID == 10)
            { card2.currentCard2.effect(); audioEffect.GetComponent<AudioSource>().Play(); cardEffectBig.SetActive(true); }

            else if ((card2.currentCard2.ID == 15) || (card2.currentCard2.ID == 8) || (card2.currentCard2.ID == 16))
            { card2.currentCard2.effect(eventData); audioEffect.GetComponent<AudioSource>().Play(); cardEffectBig.SetActive(true); }

            else if ((card2.currentCard2.ID == 2) || (card2.currentCard2.ID == 5))
            { card2.currentCard2.effect(GameManager.player2); audioEffect.GetComponent<AudioSource>().Play(); cardEffectBig.SetActive(true); }

            else if (card2.currentCard2.ID == 1)
            { card2.currentCard2.effect(eventData, GameManager.player1); audioEffect.GetComponent<AudioSource>().Play(); cardEffectBig.SetActive(true); }

            else if (card2.currentCard2.ID == 4)
            { card2.currentCard2.effect(GameManager.player2, GameManager.player1); audioEffect.GetComponent<AudioSource>().Play(); cardEffectBig.SetActive(true); }

            else if (card2.currentCard2.ID == 3)
            { card2.currentCard2.effect(GameManager.player2, GameManager.player1, eventData); audioEffect.GetComponent<AudioSource>().Play(); cardEffectBig.SetActive(true); }
        }

    }

    IEnumerator Retard(DisplayCard cardis, DisplayCard2 cardis2, GameObject eventData, GameObject controlPanels)
    {
        yield return new WaitForSeconds(1.0f);
        EffectActive(cardis, cardis2, eventData, controlPanels);
        yield return new WaitForSeconds(1.0f);

        cardEffectBig.SetActive(false);
    }
    private void AsignateImage(DisplayCard cardis,DisplayCard2 cardis2,GameObject card)
    {
        if (card.GetComponent<DisplayCard>() != null)
        {
            if (cardis.GetComponent<DisplayCard>().SpriteImage != null)
            {
                spriteCard = cardis.SpriteImage;
                imageCard.sprite = spriteCard;
            }
        }
        else if (card.GetComponent<DisplayCard2>() != null)
        {
            if (cardis2.GetComponent<DisplayCard2>().SpriteImage2 != null)
            {
                spriteCard = cardis2.GetComponent<DisplayCard2>().SpriteImage2;
                imageCard.sprite = spriteCard;
            }
        }
    }
}
